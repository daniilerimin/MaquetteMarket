using MaquetteMarket.WebAppComponents.Catalog;

namespace MaquetteMarket.WebApp.Services
{
    public interface IBasketState
    {
        public Task<IReadOnlyCollection<BasketItem>> GetBasketItemsAsync();

        public Task AddAsync(CatalogItem item);
    }
}
