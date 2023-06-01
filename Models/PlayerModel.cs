namespace AOEOTechEditorLibrary.Models;
public abstract class PlayerModel : BasicEffectModel
{
    protected override string Action => "";
    protected override string Relativity => "Absolute"; //i think always in this case.
    protected override string UnitType => "";
    protected override string DamageType => "";
    protected override string EffectType => "Data";
    protected override string TargetType => "Player";
    protected override string Status => "";
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