using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class PopupChangeOffice : Popup
{
    OfficeManagementOverviewModel OfficeManagementOverviewModel { get; set; }

	public PopupChangeOffice(OfficeManagementOverviewModel OverviewModel)
	{
		InitializeComponent();
		BindingContext = OverviewModel;
        OfficeManagementOverviewModel = OverviewModel;

    }

    private void ClosePopup_Tapped(object sender, TappedEventArgs e)
    {
        Close();
    }

    private void UpdateOffice_Clicked(object sender, EventArgs e)
    {
        OfficeManagementOverviewModel.UpdateOffice();
        OfficeManagementOverviewModel.UpdateData();
        Close();
    }
}