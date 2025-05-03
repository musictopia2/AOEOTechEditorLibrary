namespace AOEOTechEditorLibrary.Models;
public class ArmorModel(EnumDamageCategory damage) : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "Armor";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => damage.ToString();
    public override string Relativity { get; set; } = "Percent";
}