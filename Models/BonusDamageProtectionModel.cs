namespace AOEOTechEditorLibrary.Models;
public class BonusDamageProtectionModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "DamageBonusReduction";
    public override string Relativity { get; set; } = "Percent";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}