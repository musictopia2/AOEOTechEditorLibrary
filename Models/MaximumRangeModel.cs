namespace AOEOTechEditorLibrary.Models;
public class MaximumRangeModel : UnitModel
{
    protected override string Action => "RangedAttack"; //not sure about the romans siege ship (?)
    protected override string SubType => "MaximumRange";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string Relativity => "Percent";
}