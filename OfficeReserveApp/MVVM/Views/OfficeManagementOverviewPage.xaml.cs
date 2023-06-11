using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class OfficeManagementOverviewPage : ContentPage
{

	public OfficeManagementOverviewModel officeManagementOverviewModel { get; set; }

    public OfficeManagementOverviewPage()
	{
		InitializeComponent();
        officeManagementOverviewModel = new OfficeManagementOverviewModel((Image)loadingImg);
        BindingContext = officeManagementOverviewModel;

        officeManagementOverviewModel.UpdateData();
        officeManagementOverviewModel.GetOfficeInfo();
    }

    private void ChangeOffice_Tapped(object sender, TappedEventArgs e)
    {
        this.ShowPopup(new PopupChangeOffice(officeManagementOverviewModel));
    }
}