namespace AOEOTechEditorLibrary.Effects;
public class LineOfSightModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "LOS";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}