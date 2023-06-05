namespace AOEOTechEditorLibrary.Models;
public class HealRangeModel : UnitModel
{
    protected override string Action => "Heal";
    protected override string SubType => "MaximumRange";
    protected override string Relativity => "Percent";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}