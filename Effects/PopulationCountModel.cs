namespace AOEOTechEditorLibrary.Effects;
public class PopulationCountModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "PopulationCount";
    public override string Relativity { get; set; } = "Absolute";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}
