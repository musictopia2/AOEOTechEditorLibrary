namespace AOEOTechEditorLibrary.Models;
public class ConvertRate1Model : ConvertRateModel
{
    public ConvertRate1Model(EnumConvertCategory convert) : base(convert)
    {
    }
    protected override string Action => "Convert";
}