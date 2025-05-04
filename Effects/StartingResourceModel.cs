using AOEOTechEditorLibrary.Shared;

namespace AOEOTechEditorLibrary.Effects;
public class StartingResourceModel : PlayerModel
{
    private readonly EnumResource _resource;
    public StartingResourceModel(EnumResource resource)
    {
        _resource = resource;
    }
    protected override string SubType => "Resource";
    protected override string Resource => _resource.ToString();
}