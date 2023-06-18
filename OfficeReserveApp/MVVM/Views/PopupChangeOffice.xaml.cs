using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class PopupChangeOffice : Popup
{
    OfficeManagementViewModel ViewModel { get; set; }

	public PopupChangeOffice(OfficeManagementViewModel OverviewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = OverviewModel;

    }

    private void ClosePopup_Tapped(object sender, TappedEventArgs e)
    {
        Close();
    }

    private void UpdateOffice_Clicked(object sender, EventArgs e)
    {
        ViewModel.UpdateOffice();
        ViewModel.UpdateData();
        Close();
    }


}