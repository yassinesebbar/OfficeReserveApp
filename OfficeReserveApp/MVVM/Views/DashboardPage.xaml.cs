using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
		BindingContext = new DashboardPageViewModel();
	}
}