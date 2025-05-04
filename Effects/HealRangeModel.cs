namespace AOEOTechEditorLibrary.Effects;
public class HealRangeModel : UnitModel
{
    protected override string Action => "Heal";
    protected override string SubType => "MaximumRange";
    public override string Relativity { get; set; } = "Percent";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}