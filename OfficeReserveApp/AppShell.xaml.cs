using OfficeReserveApp.MVVM.ViewModels;
using OfficeReserveApp.MVVM.Views;

namespace OfficeReserveApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        Routing.RegisterRoute(nameof(OfficeReservationOverviewPage), typeof(OfficeReservationOverviewPage));
        Routing.RegisterRoute(nameof(ConferenceReservationOverviewPage), typeof(ConferenceReservationOverviewPage));

        Routing.RegisterRoute(nameof(ProfileOverviewPage), typeof(ProfileOverviewPage));

        Routing.RegisterRoute(nameof(OfficeManagementOverviewPage), typeof(OfficeManagementOverviewPage));
    }
}
