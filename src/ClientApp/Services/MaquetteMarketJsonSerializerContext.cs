using System.Text.Json.Serialization;
using MaquetteMarket.ClientApp.Models.Catalog;
using MaquetteMarket.ClientApp.Models.Orders;
using MaquetteMarket.ClientApp.Models.Token;

namespace MaquetteMarket.ClientApp.Services;

[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    NumberHandling = JsonNumberHandling.AllowReadingFromString)]
[JsonSerializable(typeof(CancelOrderCommand))]
[JsonSerializable(typeof(CatalogBrand))]
[JsonSerializable(typeof(CatalogItem))]
[JsonSerializable(typeof(CatalogRoot))]
[JsonSerializable(typeof(CatalogType))]
[JsonSerializable(typeof(Models.Orders.Order))]
[JsonSerializable(typeof(Models.Location.Location))]
[JsonSerializable(typeof(UserToken))]
internal partial class MaquetteMarketJsonSerializerContext : JsonSerializerContext
{
}
