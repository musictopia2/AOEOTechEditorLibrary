namespace AOEOTechEditorLibrary.Models;
public class MaximumTrickleResourceModel : PlayerModel
{
    private readonly EnumResource _resource;

    public MaximumTrickleResourceModel(EnumResource resource)
    {
        _resource = resource;
    }
    protected override string SubType => "MaximumResourceTrickleRate";
    protected override string Resource => _resource.ToString();
}