using MaquetteMarket.ClientApp.Services.Basket;
using MaquetteMarket.ClientApp.Services.Catalog;
using MaquetteMarket.ClientApp.Services.Identity;
using MaquetteMarket.ClientApp.Services.Order;

namespace MaquetteMarket.ClientApp.Services.AppEnvironment;

public interface IAppEnvironmentService
{
    IBasketService BasketService { get; }

    ICatalogService CatalogService { get; }

    IOrderService OrderService { get; }

    IIdentityService IdentityService { get; }

    void UpdateDependencies(bool useMockServices);
}
