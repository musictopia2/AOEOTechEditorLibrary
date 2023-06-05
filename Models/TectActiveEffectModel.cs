namespace AOEOTechEditorLibrary.Models;
public class TectActiveEffectModel : BasicEffectModel
{
    protected override string Action => "";
    protected override string SubType => "";
    protected override string Relativity => "";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string EffectType => "TechStatus";
    protected override string TargetType => "";
    protected override string Status => "active";
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
