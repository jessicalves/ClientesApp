using ClientesApp.Services;
using ClientesApp.ViewModels;
using ClientesApp.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace ClientesApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("line-awesome.ttf", "LineAwesome");
                });


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IClienteService, ClienteService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<ClienteDetailViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ClienteDetailPage>();
            return builder.Build();
        }
    }
}
