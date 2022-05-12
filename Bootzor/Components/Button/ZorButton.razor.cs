using Microsoft.AspNetCore.Components;

namespace Bootzor.Components.Button;

public partial class ZorButton : ComponentBase
{
 
    private ElementReference zorButton;

    [Parameter, EditorRequired]
    public EventCallback ClickButton { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment? Content { get; set; }

}
