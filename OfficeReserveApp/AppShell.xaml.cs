using OfficeReserveApp.MVVM.ViewModel;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		BaseViewModel BaseViewModel = new BaseViewModel();

		if (BaseViewModel.UserIsAuthenticated())
		{
            BaseViewModel.RouteBasedOnUser();
		}
		else
		{
            Shell.CurrentItem = LoginPage;
        }
		
    }
}
