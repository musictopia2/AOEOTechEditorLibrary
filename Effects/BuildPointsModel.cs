namespace AOEOTechEditorLibrary.Effects;
public class BuildPointsModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "BuildPoints";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}