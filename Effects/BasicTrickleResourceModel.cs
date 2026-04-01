namespace AOEOTechEditorLibrary.Effects;
public class BasicTrickleResourceModel(EnumResource resource) : PlayerModel
{
    protected override string SubType => "ResourceTrickleRate";
    protected override string Resource => resource.ToString();
    public override bool GrantsStone => resource == EnumResource.Stone;
}