namespace AOEOTechEditorLibrary.Components;
public partial class SimpleStandardLevelEditorContainer <T>
    where T : ILevelTech
{
    [Parameter]
    [EditorRequired]
    public BasicList<T> Techs { get; set; } = new();
    private BasicList<T> GetFilteredList(EnumTechLevel? level) => Techs.Where(x => x.Level == level).ToBasicList();
}