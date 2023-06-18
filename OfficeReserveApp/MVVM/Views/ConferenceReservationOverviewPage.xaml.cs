using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class ConferenceReservationOverviewPage : ContentPage
{

	ConferenceReservationViewModel ViewModel { get; set; }

	public ConferenceReservationOverviewPage()
	{
		InitializeComponent();
        BindingContext = ViewModel = new ConferenceReservationViewModel((Image)loadingImg);

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

    private void Barcodeicon_Pressed(object sender, EventArgs e)
    {
/*        Pressing to many times on barcode will lead to a crash of application. 
Inorder to prevent that i have disabled the button after pressing it once
*/        
        ViewModel.CanActivateBarcode = false;
        this.ShowPopup(new PopupBarcodeScanner(ViewModel));
    }

  
}