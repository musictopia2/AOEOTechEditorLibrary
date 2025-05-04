namespace AOEOTechEditorLibrary.Effects;
public class ModifySelfHealModel : UnitModel
{
    protected override string Action => "SelfHeal";
    protected override string SubType => "WorkRate";
    protected override string UnitType => "LogicalTypeHealed";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Absolute";
}