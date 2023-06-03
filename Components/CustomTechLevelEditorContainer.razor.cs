namespace AOEOTechEditorLibrary.Components;
public partial class CustomTechLevelEditorContainer
{
    [Parameter]
    [EditorRequired]
    public BasicList<CustomTechModel> Techs { get; set; } = new();
    private CustomTechModel GetTechItem(EnumTechLevel level)
    {
        return Techs!.Single(x => x.Level == level);
    }
}