using AutoMapper;
using Contracts.Events.IdentityEvents;
using MassTransit;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;

namespace Ordering.Application.EventHandlers.UserEvents;

public class BuyerCreatedConsumer : IConsumer<BuyerCreatedEvent>
{
    private readonly IBuyerRepository _buyerRepository;
    private readonly IMapper _mapper;

    public BuyerCreatedConsumer(IBuyerRepository buyerRepository, IMapper mapper)
    {
        _buyerRepository = buyerRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<BuyerCreatedEvent> context)
    {
        var buyer = _mapper.Map<Buyer>(context.Message);

        await _buyerRepository.CreateAsync(buyer, default);
    }
}
