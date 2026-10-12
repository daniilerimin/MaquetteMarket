using System.Globalization;

namespace MaquetteMarket.WebAppComponents.Services;

public static class PriceFormatter
{
    public static string ToPriceDisplay(this decimal value)
        => value.ToString("N2", CultureInfo.InvariantCulture);
}

