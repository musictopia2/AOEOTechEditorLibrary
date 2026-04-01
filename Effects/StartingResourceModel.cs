namespace AOEOTechEditorLibrary.Effects;
public class StartingResourceModel(EnumResource resource) : PlayerModel
{
    protected override string SubType => "Resource";
    protected override string Resource => resource.ToString();
    public override bool GrantsStone => resource == EnumResource.Stone;
}