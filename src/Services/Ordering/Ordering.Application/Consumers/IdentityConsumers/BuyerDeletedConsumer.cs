using Contracts.Messages.IdentityMessages;
using MassTransit;
using Ordering.Domain.Repositories;

namespace Ordering.Application.EventHandlers.UserEvents;

public class BuyerDeletedConsumer : IConsumer<BuyerDeletedMessage>
{
    private readonly IBuyerRepository _buyerRepository;

    public BuyerDeletedConsumer(IBuyerRepository buyerRepository)
    {
        _buyerRepository = buyerRepository;
    }

    public async Task Consume(ConsumeContext<BuyerDeletedMessage> context)
    {
        var buyer = await _buyerRepository.SingleOrDefaultAsync(buyer => buyer.Id == context.Message.BuyerId, default);
        if (buyer is null)
        {
            return;
        }

        await _buyerRepository.RemoveAsync(buyer, default);
    }
}
