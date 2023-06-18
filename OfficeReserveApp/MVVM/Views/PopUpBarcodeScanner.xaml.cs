using CommunityToolkit.Maui.Views;
using OfficeReserveApp.MVVM.ViewModels;
using ZXing.QrCode.Internal;

namespace OfficeReserveApp.MVVM.Views;

public partial class PopupBarcodeScanner : Popup
{

	ConferenceReservationViewModel ViewModel { get; set; }

	public PopupBarcodeScanner(ConferenceReservationViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
		cameraView.BarCodeOptions = new()
		{
			AutoRotate = true,
			PossibleFormats = new[] { ZXing.BarcodeFormat.QR_CODE }

		};

    }

	private void cameraView_CamerasLoaded(object sender, EventArgs e)
	{
		if (cameraView.Cameras.Count > 0)
		{
			cameraView.Camera = cameraView.Cameras[0];
			MainThread.BeginInvokeOnMainThread(async () =>
			{ 
				await cameraView.StopCameraAsync();
				await cameraView.StartCameraAsync();
			});
		}
	}

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
		MainThread.BeginInvokeOnMainThread(async () =>
		{
/*			ValueBarcode.Text = $"{args.Result[0].BarcodeFormat} : {args.Result[0].Text}";
*/			int num = 0;

			if(Int32.TryParse(args.Result[0].Text, out num)){
				if (ViewModel.GetConferenceById(num) != null)
				{
                    ViewModel.SetConferenceByConferenceId(num);
                    ClosePopup();
                }
				
            }

        });
    }

    private void ClosePopup_Tapped(object sender, TappedEventArgs e)
    {
		ClosePopup();
    }

	private async void ClosePopup()
	{
        await cameraView.StopCameraAsync();
        Close();
        ViewModel.CanActivateBarcode = true;

    }
}