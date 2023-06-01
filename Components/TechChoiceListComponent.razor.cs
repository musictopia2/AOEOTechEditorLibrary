namespace AOEOTechEditorLibrary.Components;
public partial class TechChoiceListComponent<T> where T : ISelectableTech
{
    [Parameter]
    [EditorRequired]
    public BasicList<T>? TechList { get; set; }
    [Parameter]
    public EventCallback OnSelected { get; set; }
    private static string CssName(T item) => item.DidChoose ? "selected" : "regular"; //for now
    public void TechClicked(T item)
    {
        item.DidChoose = !item.DidChoose;
        OnSelected.InvokeAsync(); //so the parent can do something else too (since the parent needs to update the count).
    }
}