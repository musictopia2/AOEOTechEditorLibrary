namespace AOEOTechEditorLibrary.Models;
public class BonusDamageAgainstUnitModel : UnitModel
{
    private readonly string _bonusDamageAgainst;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bonusDamageAgainst">This is the unit that it does bonus damage against.  for example, if you choose infantry, then the unit does bonus damage against infantry</param>
    public BonusDamageAgainstUnitModel(string bonusDamageAgainst)
    {
        _bonusDamageAgainst = bonusDamageAgainst;
    }
    protected override string Action => "";
    protected override string SubType => "DamageBonus";
    protected override string Relativity => "Percent";
    protected override string UnitType => _bonusDamageAgainst;
    protected override string Resource => "";
    protected override string DamageType => "";
}
