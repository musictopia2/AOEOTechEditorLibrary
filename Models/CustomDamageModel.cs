namespace AOEOTechEditorLibrary.Models;
public abstract class CustomDamageModel : UnitModel
{
    protected override string SubType => "Damage";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}
