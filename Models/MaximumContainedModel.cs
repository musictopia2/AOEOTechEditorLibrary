namespace AOEOTechEditorLibrary.Models;
public class MaximumContainedModel : UnitModel
{
    protected override string Action => "";
    protected override string SubType => "MaximumContained";
    protected override string Relativity => "Absolute";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override void Start()
    {
        if (ProtoUnit != BabylonUnits.SiegeTower)
        {
            throw new CustomBasicException("Only the babylon siege towers are allowed to change the maximum contained");
        }
        base.Start();
    }
}