namespace AOEOTechEditorLibrary.Effects;
public class VillagerCarryModel(EnumResource resource) : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "CarryCapacity";
    protected override string UnitType => "";
    protected override string Resource => resource.ToString();
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}