using AOEOTechEditorLibrary.Shared;

namespace AOEOTechEditorLibrary.Effects;
public class SpecialGatherModel(EnumResource resource) : AutoGatherModel(resource)
{
    public string CustomGatherAction { get; set; } = "";
    protected override string Action => CustomGatherAction;
    //they have to figure out the strings themselves
    protected override void Start()
    {
        if (string.IsNullOrWhiteSpace(CustomGatherAction))
        {
            throw new CustomBasicException("You must specify a custom action");
        }
        base.Start();
    }
}