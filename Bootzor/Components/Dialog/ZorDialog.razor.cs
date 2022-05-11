using Microsoft.AspNetCore.Components;
using Bootzor.ZorEnums;
using Microsoft.AspNetCore.Components.Web;

namespace Bootzor.Components.Dialog;

public partial class ZorDialog : ComponentBase
{
    //Reference to our dialog
    private ElementReference zorDialog;
     
    [Parameter, EditorRequired]
    public RenderFragment? Title { get; set; }

    /// <summary>
    /// Content of the modal
    /// </summary>
    [Parameter, EditorRequired]
    public RenderFragment? Content { get; set; } 

    /// <summary>
    /// Indicator if the Overlay has to appear
    /// true by default
    /// </summary>
    [Parameter]
    public bool Overlay { get; set; } = true;

    /// <summary>
    /// Paramenter to indicate when show the dialog. 
    /// To use you need use @ref in the modal and use NameModal.ShhowModal = true | false
    /// </summary>
    [Parameter]
    public bool ShowDialog { get; set; } = false;

    /// <summary>
    /// EventCallback<bool> to return the result 
    /// </summary>
    [Parameter, EditorRequired]
    public EventCallback<bool> ResultModal { get; set; }

    /// <summary>
    /// Type of the dialog to incate the number of buttons
    /// </summary>
    [Parameter, EditorRequired]
    public DialogButtons Buttons { get; set; }

    //Private variable to control the name of the type in the css
    private string _dialogPosition = Position.Top.GetNameClassCss();
    /// <summary>
    /// Position of the dialog
    /// DialogPosition.Top by default
    /// </summary>
    [Parameter]
    public Position DialogPosition {
        get => _dialogPosition.GetEnumType<Position>();
        set => _dialogPosition = value.GetNameClassCss();
    }
    

    //Private variable to control the name of the type in the css
    private string _dialogEffect = Effect.None.GetNameClassCss();
    /// <summary>
    /// Position of the dialog
    /// DialogPosition.Top by default
    /// </summary>
    [Parameter]
    public Effect DialogEffect {
        get => _dialogEffect.GetEnumType<Effect>();
        set => _dialogEffect = value.GetNameClassCss();
    }

    //Private variable to control the name of the type in the css
    private string _dialogIcon = DialogIcon.None.GetNameClassCss();
    /// <summary>
    /// Position of the dialog
    /// DialogIcon.None by default
    /// </summary>
    [Parameter]
    public DialogIcon Icon
    {
        get => _dialogIcon.GetEnumType<DialogIcon>();
        set => _dialogIcon = value.GetNameClassCss();
    }
        
    
    //Private variable to control the name of the type in the css
    private string _dialogColor = Color.SmoothWhite.GetNameClassCss();
    /// <summary>
    /// Position of the dialog
    /// DialogIcon.None by default
    /// </summary>
    [Parameter]
    public Color DialogColor
    {
        get => _dialogColor.GetEnumType<Color>();
        set => _dialogColor = value.GetNameClassCss();
    }


    /// <summary>
    /// Callback al presionar el botón Ok, Delete
    /// </summary>
    /// <returns>Invoca al método pasado por parámetro</returns>
    private Task ClickDialogResult(bool result)
    {
        ShowDialog = false;
        return ResultModal.InvokeAsync(result);
    }

    //TODO un dialog no suele tener Escape por que permite
    //al usuario cerrar el dialogo sin leer, lo dejo de momento
    //por aprendizaje
    //Check if press Escape key
    private void OnEscapeKeyPressed(KeyboardEventArgs e)
    {
        if (e.Key.Equals("Escape"))
            ClickDialogResult(false);
    }

    //Focus on the dialog when appear
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (ShowDialog && !firstRender)
            await zorDialog.FocusAsync();
    }

    /// <summary>
    /// Collection with the different types of the dialog
    /// </summary>
    public enum DialogButtons
    {
        Ok,
        OkCancel,
        Cancel
    }

    /// <summary>
    /// Collection with the different types of the dialog
    /// </summary>
    public enum DialogIcon
    {
        None,
        Information,
        Warning,
        Question
    }
}
