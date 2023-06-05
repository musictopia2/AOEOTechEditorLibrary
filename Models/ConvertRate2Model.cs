namespace AOEOTechEditorLibrary.Models;
public class ConvertRate2Model : ConvertRateModel
{
    public ConvertRate2Model(EnumConvertCategory convert) : base(convert)
    {
    }
    protected override string Action => "Convert2";
}