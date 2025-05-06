namespace AOEOTechEditorLibrary.Effects;
public class AutoGatherModel(EnumResource resource) : UnitModel
{
    protected override string Action => "AutoGather";
    protected override string SubType => "WorkRate";
    public override string Relativity { get; set; } = "Absolute";
    protected override string UnitType => resource.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
}