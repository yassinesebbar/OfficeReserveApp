using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class OfficeReservationOverviewPage : ContentPage
{
	private OfficeReservationViewModel ViewModel { get; set; } 

    public OfficeReservationOverviewPage()
	{
		InitializeComponent();
        // LoadingIMG Hack because Maui image animation  not working with proper binding  is an issue not solved by microsoft// 
        BindingContext = ViewModel = new OfficeReservationViewModel((Image)loadingImg);

        ViewModel.UpdateData();
      
    }

    private void DaySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DailyAvailability dailyAvailability = (DailyAvailability)OfficeDailyAvailabilitiesView.SelectedItem;

        if (dailyAvailability != null)
        {
            if (dailyAvailability.Status == StatusAvailability.Closed)
            {
                OfficeDailyAvailabilitiesView.SelectedItem = null;
            }
        }
       
    }

    private void TimeStart_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (ViewModel != null)
        {
            Boolean boolean = ViewModel.ReadyToCreateReservation;
        }
        
    }
}