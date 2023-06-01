namespace AOEOTechEditorLibrary.Models;
public class Convert1Model : ConvertModel
{
    public Convert1Model(EnumConvertCategory convert) : base(convert)
    {
    }
    protected override string Action => "Convert";
}