namespace AOEOTechEditorLibrary.Models;
public class AutoGatherModel(EnumResource resource) : UnitModel
{
    protected override string Action => "AutoGather";
    protected override string SubType => "WorkRate";
    protected override string Relativity => "Absolute";
    protected override string UnitType => resource.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
}