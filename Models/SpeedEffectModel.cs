namespace AOEOTechEditorLibrary.Models;
public class SpeedEffectModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "MaximumVelocity";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}