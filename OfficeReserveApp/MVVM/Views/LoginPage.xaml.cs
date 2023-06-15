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

    private void Button_Clicked(object sender, EventArgs e)
    {
        var pageViewObject = (LoginPageViewModel)BindingContext;
        pageViewObject.LoginAction();

        pageViewObject.RouteBasedOnIdenitity();
    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        var pageViewObject = (LoginPageViewModel)BindingContext;
        pageViewObject.LoginRequest.Password = "Semperfi123!@#";
        pageViewObject.LoginRequest.UserName = "medewerker";
        pageViewObject.LoginAction();

        pageViewObject.RouteBasedOnIdenitity();
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {
        var pageViewObject = (LoginPageViewModel)BindingContext;
        pageViewObject.LoginRequest.Password = "Semperfi123!@#";
        pageViewObject.LoginRequest.UserName = "officemedewerkerutrecht";
        pageViewObject.LoginAction();

        pageViewObject.RouteBasedOnIdenitity();
    }
}