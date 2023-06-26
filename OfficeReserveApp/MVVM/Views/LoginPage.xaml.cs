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
        ViewModel.Login();
        if (ViewModel.UserIsAuthenticated())
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
        ViewModel.Login();

        ViewModel.RouteBasedOnIdenitity();
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {
        ViewModel.LoginRequest.Password = "Avansbreda2@";
        ViewModel.LoginRequest.UserName = "officemedewerkerutrecht";
        ViewModel.Login();

        ViewModel.RouteBasedOnIdenitity();
    }
}