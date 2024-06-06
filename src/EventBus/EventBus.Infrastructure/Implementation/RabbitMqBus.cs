﻿using EventBus.Domain.Abstractions;
using EventBus.Domain.Entities;
using EventBus.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBus.Infrastructure.Implementation;

public class RabbitMqBus : IEventBus
{
    private readonly string _hostName;
    private readonly List<Type> _eventTypes;
    private readonly Dictionary<string, List<Type>> _handlers;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public RabbitMqBus(string hostName, IServiceScopeFactory serviceScopeFactory)
    {
        _hostName = hostName;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Publish<T>(T @event) where T : Event
    {
        var factory = new ConnectionFactory()
        {
            HostName = _hostName
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        var eventName = @event.GetType().Name;

        channel.QueueDeclare(eventName, false, false, false, null);
        
        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);
        
        channel.BasicPublish("", eventName, null, body);
    }

    public void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T)))
        {
            _eventTypes.Add(typeof(T));
        }

        if (!_handlers.ContainsKey(eventName))
        {
            _handlers.Add(eventName, new List<Type>());
        }

        if (_handlers[eventName].Any(type => type == handlerType))
        {
            throw new ArgumentException($"Handler Type {handlerType.Name} already is registered for '{eventName}'", nameof(handlerType));
        }

        _handlers[eventName].Add(handlerType);

        StartBasicConsumer<T>();
    }

    private void StartBasicConsumer<T>() where T : Event
    {
        var factory = new ConnectionFactory()
        {
            HostName = _hostName,
            DispatchConsumersAsync = true
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        var eventName = typeof(T).Name;
        channel.QueueDeclare(eventName, false, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;

        channel.BasicConsume(eventName, false, consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.Span);

        await ProcessEvent(eventName, message).ConfigureAwait(false);

        var consumer = sender as AsyncDefaultBasicConsumer ?? throw new Exception("invalid cast of sender");

        consumer.Model.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.ContainsKey(eventName))
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var subscribers = _handlers[eventName];
                foreach (var subscriber in subscribers)
                {
                    var handler = scope.ServiceProvider.GetService(subscriber);

                    if (handler == null)
                    {
                        continue;
                    }

                    var eventType = _eventTypes.Single(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType);
                    var specificType = typeof(IEventHandler<>).MakeGenericType(eventType);

                    await (Task)specificType.GetMethod("Handle").Invoke(handler, new object[] { @event });

                }
            }

        }
    }
}