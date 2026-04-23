namespace AOEOTechEditorLibrary.Effects;

public class CaravanTradeRateModel : UnitModel
{
    protected override string Action => "Tade";
    protected override string SubType => "WorkRate";
    protected override string Resource => "";
    protected override string UnitType => "AbstractTownCenter";
    protected override string DamageType => "";
    public override string Relativity { get; set; } = "Percent";
}