namespace AOEOTechEditorLibrary.Models;
public class PopulationCapAdditionModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "PopulationCapAddition";
    public override string Relativity { get; set; } = "Assign";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}