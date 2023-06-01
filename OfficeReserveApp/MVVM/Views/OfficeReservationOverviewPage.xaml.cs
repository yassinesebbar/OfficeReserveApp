using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using OfficeReserveApp.MVVM.ViewModels;


namespace OfficeReserveApp.MVVM.Views;

public partial class OfficeReservationOverviewPage : ContentPage
{
	private OfficeReservationOverviewModel OfficeReservationOverviewModel { get; set; } = new OfficeReservationOverviewModel();

    public OfficeReservationOverviewPage()
	{
		InitializeComponent();
		BindingContext = OfficeReservationOverviewModel;

        OfficeReservationOverviewModel.GetMyOfficeReservations();
		OfficeReservationOverviewModel.GetDailyAvailability();

		
    }
}