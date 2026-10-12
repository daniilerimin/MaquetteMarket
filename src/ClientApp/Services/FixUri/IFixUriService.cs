using MaquetteMarket.ClientApp.Models.Basket;
using MaquetteMarket.ClientApp.Models.Catalog;
using MaquetteMarket.ClientApp.Models.Marketing;

namespace MaquetteMarket.ClientApp.Services.FixUri;

public interface IFixUriService
{
    void FixCatalogItemPictureUri(IEnumerable<CatalogItem> catalogItems);
    void FixBasketItemPictureUri(IEnumerable<BasketItem> basketItems);
    void FixCampaignItemPictureUri(IEnumerable<CampaignItem> campaignItems);
}
