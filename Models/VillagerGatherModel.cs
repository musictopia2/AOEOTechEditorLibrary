namespace AOEOTechEditorLibrary.Models;
public class VillagerGatherModel(EnumGatherCategory category) : UnitModel
{
    protected override string Action => "Gather";
    protected override string SubType => "WorkRate";
    protected override string UnitType => category.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string Relativity => "Percent";
}