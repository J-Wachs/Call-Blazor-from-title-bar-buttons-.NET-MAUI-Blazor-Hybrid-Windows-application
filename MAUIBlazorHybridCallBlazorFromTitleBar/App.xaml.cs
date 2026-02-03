using MAUIBlazorHybridCallBlazorFromTitleBar.Helpers;

namespace MAUIBlazorHybridCallBlazorFromTitleBar;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window? window = null;
        string winTitle = ".NET MAUI Blazor Hybrid";

        if (Microsoft.UI.Windowing.AppWindowTitleBar.IsCustomizationSupported())
        {
#if WINDOWS
            string subTitle = "Call Blazor from the Title Bar";
            string superMaximizeToolTip = "Maximize across all screens";
            var titleBar = SuperMaximizeForWindows.BuildTitleBar(winTitle, subTitle, superMaximizeToolTip);

            string gearToolTip = "Settings";
            var gearButton = TitleBarTools.CreateCallBlazorTitleBarButton("\uF4CA", gearToolTip, TitleBarButtonIds.Settings); // Settings icon
            // As 'Super Maximize' is already added, we just add the 'Settings' button next to it
            TitleBarTools.AddButtonToTrailingContent(titleBar, gearButton);

            string sendMessageToolTip = "Send a message";
            var sendMessageButton = TitleBarTools.CreateCallBlazorTitleBarButton("\uF507", sendMessageToolTip, TitleBarButtonIds.SendMessage); // Envelope icon
            // Add the 'SendMessage' button
            TitleBarTools.AddButtonToTrailingContent(titleBar, sendMessageButton);

            string helpToolTip = "Display help text";
            var helpButton = TitleBarTools.CreateCallBlazorTitleBarButton("\uF637", helpToolTip, TitleBarButtonIds.Help); // Question mark icon
            // Add the 'Help' button
            TitleBarTools.AddButtonToTrailingContent(titleBar, helpButton);

            window = new Window(new MainPage())
            {
                TitleBar = titleBar
            };

            // Listener for the Created event to get the native window
            // as we need the position and size that Windows has set
            window.Created += (sender, eventArgs) =>
            {
                var mauiWindow = sender as Microsoft.Maui.Controls.Window;
                if (mauiWindow?.Handler?.PlatformView is Microsoft.UI.Xaml.Window nativeWindow)
                {
                    SuperMaximizeForWindows.Initialize(nativeWindow);
                }
                else
                {
                    throw new InvalidOperationException("Failed to get native window for Super Maximize initialization.");
                }
            };
#else
            window = new Window(new MainPage()) { Title = winTitle };
#endif
        }
        else
            window = new Window(new MainPage()) { Title = winTitle };

        return window;
    }
}
