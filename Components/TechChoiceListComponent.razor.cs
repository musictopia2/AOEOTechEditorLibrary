namespace AOEOTechEditorLibrary.Components;
public partial class TechChoiceListComponent<T> where T : ISelectableTech
{
    [Parameter]
    [EditorRequired]
    public BasicList<T>? TechList { get; set; }
    [Parameter]
    public EventCallback OnSelected { get; set; }
}