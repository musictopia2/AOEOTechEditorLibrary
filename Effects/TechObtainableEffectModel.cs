namespace AOEOTechEditorLibrary.Effects;
public class TechObtainableEffectModel : BasicEffectModel
{
    protected override string Action => "";
    protected override string SubType => "";
    public override string Relativity { get; set; } = "";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string EffectType => "TechStatus";
    protected override string TargetType => "";
    protected override string Status => "obtainable";
    protected override void Start()
    {
        if (ProtoUnit != "")
        {
            ProtoUnit = "";
        }
        if (Content == "")
        {
            throw new CustomBasicException("Must have the tech that is enabled.  Goes under Content");
        }
        base.Start();
    }
}