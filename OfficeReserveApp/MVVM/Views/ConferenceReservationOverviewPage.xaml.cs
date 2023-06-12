using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class ConferenceReservationOverviewPage : ContentPage
{

	ConferenceReservationViewModel ViewModel { get; set; }

	public ConferenceReservationOverviewPage()
	{
		InitializeComponent();
        ViewModel = new ConferenceReservationViewModel((Image)loadingImg);
        BindingContext = ViewModel;
        ViewModel.UpdateData();
        ViewModel.GetDailyAvailability();
        ViewModel.GetOffices();
        ViewModel.GetConferences();

    }

    private void picker_OfficeSelectedIndexChanged(object sender, EventArgs e)
    {
        ViewModel.FilterConferences();
    }

    private void DaySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DailyAvailability dailyAvailability = (DailyAvailability)ViewModel.SelectedDay;

        if (dailyAvailability != null)
        {
            if (!ViewModel.SelectDayIsEnabled)
            {
                OfficeDailyAvailabilitiesView.SelectedItem = null;
            }
            else
            {
                ViewModel.GetReservationsByConferenceAndDate();
            }
        }

    }
}