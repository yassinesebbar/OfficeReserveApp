using OfficeReserveApp.MVVM.ViewModels;

namespace OfficeReserveApp.MVVM.Views;

public partial class ProfileOverviewPage : ContentPage
{
	public ProfileOverviewPage()
	{
		InitializeComponent();
		BindingContext = new BaseViewModel();
	}
}