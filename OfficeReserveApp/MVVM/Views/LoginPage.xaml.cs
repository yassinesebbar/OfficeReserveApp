using OfficeReserveApp.MVVM.ViewModel;

namespace OfficeReserveApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}