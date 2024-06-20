﻿using Contracts.Events.IdentityEvents;
using MassTransit;
using Ordering.Domain.Repositories;

namespace Ordering.Application.EventHandlers.UserEvents;

public class BuyerDeletedConsumer : IConsumer<BuyerDeletedEvent>
{
    private readonly IBuyerRepository _buyerRepository;

    public BuyerDeletedConsumer(IBuyerRepository buyerRepository)
    {
        _buyerRepository = buyerRepository;
    }

    public async Task Consume(ConsumeContext<BuyerDeletedEvent> context)
    {
        var buyer = await _buyerRepository.SingleOrDefaultAsync(buyer => buyer.Id == context.Message.BuyerId, default);
        if (buyer is null)
        {
            return;
        }

        await _buyerRepository.RemoveAsync(buyer, default);
    }
}