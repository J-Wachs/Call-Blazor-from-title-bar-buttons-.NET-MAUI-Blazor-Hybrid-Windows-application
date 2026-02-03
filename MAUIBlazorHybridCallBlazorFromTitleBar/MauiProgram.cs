using Microsoft.Extensions.Logging;
using MAUIBlazorHybridCallBlazorFromTitleBar.Application.Interfaces;
using MAUIBlazorHybridCallBlazorFromTitleBar.Infrastructure.Services;

namespace MAUIBlazorHybridCallBlazorFromTitleBar;

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
                fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentSystemIcons");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // Register the TitleBarService for managing title bar text
        builder.Services.AddSingleton<ITitleBarService, TitleBarService>();


        return builder.Build();
    }
}
