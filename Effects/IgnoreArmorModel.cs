namespace AOEOTechEditorLibrary.Effects;
public class IgnoreArmorModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "ArmorVulnerability";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Absolute";
}