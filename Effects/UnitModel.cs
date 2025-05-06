namespace AOEOTechEditorLibrary.Effects;
public abstract class UnitModel : BasicEffectModel
{
    protected override string EffectType => "Data";
    protected override string TargetType => "ProtoUnit";
    protected override string Status => "";
    protected override void Start()
    {
        Content = "";
        if (ProtoUnit == "")
        {
            throw new CustomBasicException("Must have the unit used");
        }
        base.Start();
    }
}