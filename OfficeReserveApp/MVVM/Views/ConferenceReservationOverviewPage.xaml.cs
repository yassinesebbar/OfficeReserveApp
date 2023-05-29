using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class ConferenceReservationOverviewPage : ContentPage
{
	public ConferenceReservationOverviewPage()
	{
		InitializeComponent();
		BindingContext = new DashboardPageViewModel();
	}
}