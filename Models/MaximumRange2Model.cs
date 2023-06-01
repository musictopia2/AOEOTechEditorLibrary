namespace AOEOTechEditorLibrary.Models;
public class MaximumRange2Model : MaximumRangeModel
{
    public MaximumRange2Model()
    {
        ProtoUnit = RomanUnits.Enneris; //default to that unit.
    }
    protected override string Action => "RangedAttack2";
    protected override void Start()
    {
        if (ProtoUnit != RomanUnits.Enneris)
        {
            throw new CustomBasicException($"For now, the only unit that should have been used is {RomanUnits.Enneris}");
        }
        base.Start();
    }
}