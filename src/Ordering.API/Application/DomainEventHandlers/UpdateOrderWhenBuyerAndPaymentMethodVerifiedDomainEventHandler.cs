namespace MaquetteMarket.Ordering.API.Application.DomainEventHandlers;

public class UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler : INotificationHandler<BuyerAndPaymentMethodVerifiedDomainEvent>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger _logger;

    public UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler(
        IOrderRepository orderRepository,
        ILogger<UpdateOrderWhenBuyerAndPaymentMethodVerifiedDomainEventHandler> logger)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(BuyerAndPaymentMethodVerifiedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        var orderToUpdate = await _orderRepository.GetAsync(domainEvent.OrderId);
        orderToUpdate.SetPaymentMethodVerified(domainEvent.Buyer.Id, domainEvent.Payment.Id); 
        OrderingApiTrace.LogOrderPaymentMethodUpdated(_logger, domainEvent.OrderId, nameof(domainEvent.Payment), domainEvent.Payment.Id);
    }
}

