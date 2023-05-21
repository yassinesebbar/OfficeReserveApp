namespace OfficeReserveApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		var userLoggedIn = Preferences.Get("UserLoggedIn", false);

		if (userLoggedIn)
		{
            Shell.CurrentItem = DashboardPage;
        }
		else
		{
            Shell.CurrentItem = LoginPage;
		}
    }
}
