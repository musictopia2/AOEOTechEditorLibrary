namespace AOEOTechEditorLibrary.Models;
public class VillagerGatherModel : UnitModel
{
    private readonly EnumGatherCategory _category;
    public VillagerGatherModel(EnumGatherCategory category)
    {

        _category = category;
    }
    protected override string Action => "Gather";
    protected override string SubType => "WorkRate";
    protected override string UnitType => _category.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string Relativity => "Percent";
}