namespace MAUIBlazorHybridCallBlazorFromTitleBar.Application.Interfaces;

/// <summary>
/// Interface defining methods and events for managing the title bar's title and subtitle.
/// </summary>
public interface ITitleBarService
{
    /// <summary>
    /// Notifies the Blazor application that a button with the specified identifier has been activated.
    /// </summary>
    /// <param name="buttonId">The unique identifier of the button that triggered the notification. Cannot be null or empty.</param>
    void NotifyBlazor(string buttonId);

    /// <summary>
    /// Sets the title of the title bar.
    /// </summary>
    /// <param name="title"></param>
    void SetTitle(string? title);

    /// <summary>
    /// Sets the subtitle of the title bar.
    /// </summary>
    /// <param name="subtitle"></param>
    void SetSubtitle(string? subtitle);

    /// <summary>
    /// Event triggered when a WinUI3 button wants to notify Blazor.
    /// </summary>
    event Action<string>? BlazorCalled;

    /// <summary>
    /// Event triggered when the title changes.
    /// </summary>
    event Action<string?>? TitleChanged;

    /// <summary>
    /// Event triggered when the subtitle changes.
    /// </summary>
    event Action<string?>? SubtitleChanged;
}
