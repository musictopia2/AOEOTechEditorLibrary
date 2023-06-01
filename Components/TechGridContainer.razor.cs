namespace AOEOTechEditorLibrary.Components;
public partial class TechGridContainer
{
    [Parameter]
    public RenderFragment? FirstColumnContent { get; set; }
    [Parameter]
    public RenderFragment? SecondColumnContent { get; set; }
    [Parameter]
    public RenderFragment? ThirdColumnContent { get; set; }
    [Parameter]
    public RenderFragment? FourthColumnContent { get; set; }
    private string ColumnInfo => FourthColumnContent is null ? "1fr 1fr 1fr" : "1fr 1fr 1fr 1fr";
    private string Width => FourthColumnContent is null ? "width: 32vw;" : "width: 24vw;";
}