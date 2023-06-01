namespace AOEOTechEditorLibrary.Models;
public class VillagerCarryModel : UnitModel
{
    private readonly EnumResource _resource;
    public VillagerCarryModel(EnumResource resource)
    {
        _resource = resource;
    }
    protected override string Action => "";
    protected override string SubType => "CarryCapacity";
    protected override string UnitType => "";
    protected override string Resource => _resource.ToString();
    protected override string DamageType => "";
    protected override string Relativity => "Percent";
}