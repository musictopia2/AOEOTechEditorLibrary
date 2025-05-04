namespace AOEOTechEditorLibrary.Effects;
public class HitPointsModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "Hitpoints";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}