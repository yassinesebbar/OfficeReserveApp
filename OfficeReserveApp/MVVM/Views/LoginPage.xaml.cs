using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
    BaseViewModel ViewModel;

    public LoginPage()
	{
		InitializeComponent();
		BindingContext =  ViewModel = new BaseViewModel();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.LoginRequest = new LoginRequestModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
         Login();
    }

    private async Task Login()
    {
        await ViewModel.Login();
        if (ViewModel.UserIsAuthenticated())
        {
            ViewModel.RouteBasedOnIdenitity();
        }
        else
        {
            await DisplayAlert("Login mislukt", "Het ingevoerde gebruikersnaam of wachtwoord is onjuist", "Ok");
        }
    }

}