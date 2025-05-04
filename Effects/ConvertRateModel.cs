namespace AOEOTechEditorLibrary.Effects;
public abstract class ConvertRateModel(EnumConvertCategory convert) : UnitModel
{
    protected override string SubType => "WorkRate";
    public override string Relativity { get; set; } = "Percent";
    protected override string UnitType => convert.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
}