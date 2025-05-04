namespace AOEOTechEditorLibrary.Effects;
public abstract class MaximumRangeModel : UnitModel
{
    protected override string SubType => "MaximumRange";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}