using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class OfficeManagementOverviewPage : ContentPage
{

	private OfficeManagementViewModel ViewModel { get; set; }

    public OfficeManagementOverviewPage()
	{
		InitializeComponent();
        BindingContext = ViewModel = new OfficeManagementViewModel((Image)loadingImg);

        ViewModel.UpdateData();
        ViewModel.GetOfficeInfo();
    }

    private void ChangeOffice_Tapped(object sender, TappedEventArgs e)
    {
        this.ShowPopup(new PopupChangeOffice(ViewModel));
    }
}