using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using OfficeReserveApp.MVVM.Models;
using OfficeReserveApp.MVVM.ViewModels;
using PropertyChanged;

namespace OfficeReserveApp.MVVM.Views;

public partial class OfficeReservationOverviewPage : ContentPage
{
	private OfficeReservationOverviewModel OfficeReservationOverviewModel { get; set; } 

    public OfficeReservationOverviewPage()
	{
		InitializeComponent();
                // LoadingIMG Hack because Maui image animation  not working with proper binding  is an issue not solved by microsoft// 
        OfficeReservationOverviewModel = new OfficeReservationOverviewModel((Image)loadingImg);
        BindingContext = OfficeReservationOverviewModel;

        OfficeReservationOverviewModel.UpdateData();
      
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
}