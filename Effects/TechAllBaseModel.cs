namespace AOEOTechEditorLibrary.Effects;
public abstract class TechAllBaseModel : BasicEffectModel
{
    protected override string Action => "";
    public override string Relativity { get; set; } = "Percent";
    protected override string UnitType => "";
    protected override string DamageType => "";
    protected override string EffectType => "Data";
    protected override string TargetType => "TechAll";
    protected override string Status => "";
    protected override string Resource => "";
    protected override void Start()
    {
        if (ProtoUnit != "")
        {
            ProtoUnit = "";
        }
        if (Content != "")
        {
            Content = ""; //never content for this.
        }
        base.Start();
    }
}