namespace AOEOTechEditorLibrary.Components;
public partial class SimpleStandardLevelEditorListComponent<T>
    where T : ILevelTech
{
    [Parameter]
    [EditorRequired]
    public BasicList<T> Techs { get; set; } = new();
    private bool CanEdit => Techs.First().Level is not null;
    private string DisplayName()
    {
        var milestone = Techs.First();
        if (milestone.Level is null)
        {
            return "Original";
        }
        return milestone.Level.ToString()!;
    }
}