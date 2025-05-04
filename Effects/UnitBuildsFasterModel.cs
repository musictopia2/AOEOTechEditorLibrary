namespace AOEOTechEditorLibrary.Effects;
public class UnitBuildsFasterModel : UnitModel //obviously, if the value is set to lower than 1, then will actually build slower.
{
    protected override string Action => "Build";
    protected override string SubType => "WorkRate";
    protected override string UnitType => "Building";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}