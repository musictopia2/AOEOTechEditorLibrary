namespace AOEOTechEditorLibrary.Effects;
public class TrainingPointsModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "TrainPoints";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => ""; 
    public override string Relativity { get; set; } = "Percent";
}