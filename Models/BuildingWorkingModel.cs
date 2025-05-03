namespace AOEOTechEditorLibrary.Models;
public class BuildingWorkingModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "BuildingWorkRate";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}