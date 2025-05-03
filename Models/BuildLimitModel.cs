namespace AOEOTechEditorLibrary.Models;
public class BuildLimitModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "BuildLimit";
    public override string Relativity { get; set; } = "Absolute";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}