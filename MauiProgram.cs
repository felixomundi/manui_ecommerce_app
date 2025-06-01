using Microsoft.Extensions.Logging;
using ecommerce_app.Services;
using ecommerce_app.ViewModels;
using ecommerce_app.Pages.Auth;
namespace ecommerce_app
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton(sp => new HttpClient
            {
                BaseAddress = new Uri("http://10.0.2.2:3011/api/v1/") // Use LAN IP for physical device
            });
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<UsersViewModel>();
            builder.Services.AddSingleton<DashboardViewModel>();
            builder.Services.AddSingleton<UsersPage>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // return builder.Build();
            var mauiApp = builder.Build();
            App.Init(mauiApp.Services); // ✅ Important!
            return mauiApp;
        }
    }
}
