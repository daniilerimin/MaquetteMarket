using MaquetteMarket.ClientApp.Services;
using MaquetteMarket.ClientApp.ViewModels.Base;

namespace MaquetteMarket.ClientApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService)
        : base(navigationService)
    {
    }

    [RelayCommand]
    private async Task SettingsAsync()
    {
        await NavigationService.NavigateToAsync("Settings");
    }
}
