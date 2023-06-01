namespace AOEOTechEditorLibrary.Components;
public partial class TechValuePairEditorComponent
{
    [Parameter]
    [EditorRequired]
    public BasicList<TechValuePairModel> Pairs { get; set; } = new();
    [Parameter]
    public bool CanEdit { get; set; }
}