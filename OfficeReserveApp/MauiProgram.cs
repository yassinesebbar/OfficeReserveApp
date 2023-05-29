using Microsoft.Extensions.Logging;
using OfficeReserveApp.Services;

namespace OfficeReserveApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Black.ttf", "Strong");
                fonts.AddFont("LibreFranklin-Regular.ttf", "Regular");
            });


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
