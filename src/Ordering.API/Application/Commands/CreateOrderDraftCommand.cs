namespace MaquetteMarket.Ordering.API.Application.Commands;
using MaquetteMarket.Ordering.API.Application.Models;

public record CreateOrderDraftCommand(string BuyerId, IEnumerable<BasketItem> Items) : IRequest<OrderDraftDTO>;
