namespace AOEOTechEditorLibrary.Effects;
public class TerminateUnitModel : HitPointsModel
{
    public override string Relativity { get; set; } = "Assign";
    protected override void Start()
    {
        Value = "0.000";
        base.Start();
    }
}