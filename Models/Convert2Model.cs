namespace AOEOTechEditorLibrary.Models;
public class Convert2Model : ConvertModel
{
    public Convert2Model(EnumConvertCategory convert) : base(convert)
    {
    }
    protected override string Action => "Convert2";
}