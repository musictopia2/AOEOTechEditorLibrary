namespace AOEOTechEditorLibrary.Models;
public class BasicTrickleResourceModel : PlayerModel
{
    private readonly EnumResource _resource;
    public BasicTrickleResourceModel(EnumResource resource)
    {
        _resource = resource;
    }

    protected override string SubType => "ResourceTrickleRate";
    protected override string Resource => _resource.ToString();
}