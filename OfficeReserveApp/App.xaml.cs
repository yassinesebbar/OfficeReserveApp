using OfficeReserveApp.Services;

namespace OfficeReserveApp;

public partial class App : Application
{

	public static HttpClient client  { get; private set; } = new HttpClient();
	public static AuthenticationService authenticationService { get; private set; } = new AuthenticationService();

	public App()
	{
		InitializeComponent();		

		MainPage = new AppShell();
	}
}
