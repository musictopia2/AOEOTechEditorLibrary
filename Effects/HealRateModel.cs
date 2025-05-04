namespace AOEOTechEditorLibrary.Effects;
public class HealRateModel : UnitModel
{
    protected override string Action => "Heal";
    protected override string SubType => "WorkRate";
    public override string Relativity { get; set; } = "Percent";
    protected override string UnitType => "LogicalTypeHealed";
    protected override string Resource => "";
    protected override string DamageType => "";
}