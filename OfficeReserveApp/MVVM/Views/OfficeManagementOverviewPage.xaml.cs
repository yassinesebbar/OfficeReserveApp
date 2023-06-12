using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class OfficeManagementOverviewPage : ContentPage
{

	public OfficeManagementViewModel ViewModel { get; set; }

    public OfficeManagementOverviewPage()
	{
		InitializeComponent();
        ViewModel = new OfficeManagementViewModel((Image)loadingImg);
        BindingContext = ViewModel;

        ViewModel.UpdateData();
        ViewModel.GetOfficeInfo();
    }

    private void ChangeOffice_Tapped(object sender, TappedEventArgs e)
    {
        this.ShowPopup(new PopupChangeOffice(ViewModel));
    }
}