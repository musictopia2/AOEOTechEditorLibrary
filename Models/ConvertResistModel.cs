namespace AOEOTechEditorLibrary.Models;
public class ConvertResistModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "ConvertResist";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}