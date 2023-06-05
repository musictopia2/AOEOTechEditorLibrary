namespace AOEOTechEditorLibrary.Models;
public abstract class ConvertRateModel : UnitModel
{
    private readonly EnumConvertCategory _convert;

    public ConvertRateModel(EnumConvertCategory convert)
    {
        _convert = convert;
    }
    protected override string SubType => "WorkRate";
    protected override string Relativity => "Percent";
    protected override string UnitType => _convert.ToString();
    protected override string Resource => "";
    protected override string DamageType => "";
}