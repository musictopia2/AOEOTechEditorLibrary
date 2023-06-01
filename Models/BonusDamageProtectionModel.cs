namespace AOEOTechEditorLibrary.Models;
public class BonusDamageProtectionModel : UnitModel
{
    private readonly string _bonusDamageAgainst;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bonusDamageAgainst">This is the unit that it does bonus damage against.  for example, if you choose infantry, then the unit does bonus damage against infantry</param>
    public BonusDamageProtectionModel(string bonusDamageAgainst)
    {
        _bonusDamageAgainst = bonusDamageAgainst;
    }
    protected override string Action => "";
    protected override string SubType => "DamageBonusReduction";
    protected override string Relativity => "Percent";
    protected override string UnitType => _bonusDamageAgainst;
    protected override string Resource => "";
    protected override string DamageType => "";
}