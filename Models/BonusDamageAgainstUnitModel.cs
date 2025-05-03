namespace AOEOTechEditorLibrary.Models;
/// <summary>
/// 
/// </summary>
/// <param name="bonusDamageAgainst">This is the unit that it does bonus damage against.  for example, if you choose infantry, then the unit does bonus damage against infantry</param>
public class BonusDamageAgainstUnitModel(string bonusDamageAgainst) : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "DamageBonus";
    public override string Relativity { get; set; } = "Percent";
    protected override string UnitType => bonusDamageAgainst;
    protected override string Resource => "";
    protected override string DamageType => "";
}
