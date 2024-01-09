using BrewBiteCafe.Services.Admin.Service;
using BrewBiteCafe.Services.Coffee.Service;
using BrewBiteCafe.Services.Staff.Service;
using BrewBiteCafe.Utils.AuthServices;
using Microsoft.Extensions.Logging;
namespace BrewBiteCafe
{
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddSingleton<AdminService>();
            builder.Services.AddSingleton<CoffeeService>();
            builder.Services.AddSingleton<NotificationService>();
            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddSingleton<ActionService>();
            builder.Services.AddSingleton<StaffService>();
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
