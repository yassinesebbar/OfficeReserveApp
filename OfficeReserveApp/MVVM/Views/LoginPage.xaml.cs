using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModel;

namespace OfficeReserveApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var LoginPageViewModel = (LoginPageViewModel)BindingContext;
        LoginPageViewModel.LoginRequest = new LoginRequestModel();
    }

}