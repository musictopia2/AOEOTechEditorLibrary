namespace AOEOTechEditorLibrary.Effects;
public class MaximumTrickleResourceModel(EnumResource resource) : PlayerModel
{
    protected override string SubType => "MaximumResourceTrickleRate";
    protected override string Resource => resource.ToString();
}