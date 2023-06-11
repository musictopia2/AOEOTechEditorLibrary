namespace AOEOTechEditorLibrary.Models;
public class ArmorModel : UnitModel
{
    private readonly EnumDamageCategory _damage;
    public ArmorModel(EnumDamageCategory damage)
    {
        _damage = damage;
    }
    protected override string Action => "";
    protected override string SubType => "Armor";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => _damage.ToString();
    protected override string Relativity => "Percent";
}