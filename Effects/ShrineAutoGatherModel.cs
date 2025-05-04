using AOEOTechEditorLibrary.Shared;

namespace AOEOTechEditorLibrary.Effects;
public class ShrineAutoGatherModel(EnumResource resource) : AutoGatherModel(resource)
{
    protected override string Action => "ShrineGather";
}