using MaquetteMarket.ClientApp.Services.Identity;
using MaquetteMarket.ClientApp.Services.RequestProvider;
using MaquetteMarket.ClientApp.Services.Settings;

namespace MaquetteMarket.ClientApp.Services.Location;

public class LocationService : ILocationService
{
    private const string ApiUrlBase = "l/api/v1/locations";
    private readonly IIdentityService _identityService;

    public LocationService(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task UpdateUserLocation(Models.Location.Location newLocReq)
    {
        var accessToken = await _identityService.GetAuthTokenAsync().ConfigureAwait(false);

        if (string.IsNullOrEmpty(accessToken))
        {
            return;
        }

        await Task.Delay(10).ConfigureAwait(false);
    }
}

