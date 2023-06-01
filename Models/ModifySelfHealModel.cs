namespace AOEOTechEditorLibrary.Models;
public class ModifySelfHealModel : UnitModel
{
    protected override string Action => "SelfHeal";
    protected override string SubType => "WorkRate";
    protected override string UnitType => "LogicalTypeHealed";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string Relativity => "Absolute";
}