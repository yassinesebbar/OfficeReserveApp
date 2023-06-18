using CommunityToolkit.Maui.Alerts;
using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModel;

namespace OfficeReserveApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
    LoginPageViewModel ViewModel = new LoginPageViewModel();   

    public LoginPage()
	{
		InitializeComponent();
		BindingContext =  ViewModel = new LoginPageViewModel();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.LoginRequest = new LoginRequestModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ViewModel.LoginAction();
        if (ViewModel.LoginIsSuccessful())
        {
            ViewModel.RouteBasedOnIdenitity();
        }
        else
        {
            DisplayAlert("Login mislukt", "Het ingevoerde gebruikersnaam of wachtwoord is onjuist", "Ok");
        }
    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        ViewModel.LoginRequest.Password = "Avansbreda1!";
        ViewModel.LoginRequest.UserName = "medewerker";
        ViewModel.LoginAction();

        ViewModel.RouteBasedOnIdenitity();
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {
        ViewModel.LoginRequest.Password = "Avansbreda2@";
        ViewModel.LoginRequest.UserName = "officemedewerkerutrecht";
        ViewModel.LoginAction();

        ViewModel.RouteBasedOnIdenitity();
    }
}