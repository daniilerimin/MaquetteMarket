using MaquetteMarket.ClientApp.Models.User;

namespace MaquetteMarket.ClientApp.Services.Identity;

public interface IIdentityService
{
    Task<bool> SignInAsync();

    Task<bool> SignOutAsync();

    Task<UserInfo> GetUserInfoAsync();

    Task<string> GetAuthTokenAsync();
}
