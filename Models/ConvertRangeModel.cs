namespace AOEOTechEditorLibrary.Models;
public abstract class ConvertRangeModel : UnitModel
{
    public ConvertRangeModel()
    {
        
    }
    protected override string SubType => "MaximumRange";
    protected override string Relativity => "Percent";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
}