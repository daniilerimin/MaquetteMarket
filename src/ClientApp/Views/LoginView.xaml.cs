namespace MaquetteMarket.ClientApp.Views;

public partial class LoginView
{
    private readonly LoginViewModel _viewModel;

    public LoginView(LoginViewModel viewModel)
    {
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        var content = Content;
        Content = null;
        Content = content;

        _viewModel.InvalidateMock();
    }
}

