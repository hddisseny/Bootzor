using Microsoft.AspNetCore.Components;

namespace Bootzor.Components.Alert;

/// <summary>
/// Class to Alerts
/// </summary>
public partial class ZorAlert
{
    /// <summary>
    /// Visible title text 
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// TypeAlert is the name of the css class that is assigned to the item
    /// - primary
    /// - secondary
    /// - success
    /// - fail
    /// - warning
    /// - info
    /// </summary>
    [Parameter]
    public string? TypeAlert { get; set; }

    /// <summary>
    /// Set up if show icon before text
    /// </summary>
    [Parameter]
    public string Icon { get; set; } = string.Empty;
}
