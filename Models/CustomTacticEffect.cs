namespace AOEOTechEditorLibrary.Models;
public class CustomTacticEffect() : UnitModel
{
    public string CustomTacticName { get; set; } = ""; //was going to require to put into constructors.  the problem is for now, i can't serialize/deserialize.
    protected override string Action => CustomTacticName;
    protected override string SubType => "ActionEnable";
    protected override string UnitType => "";
    protected override string Resource => "";
    protected override string DamageType => "";
    protected override string Relativity => "Absolute";
    protected override void Start()
    {
        if (CustomTacticName == "")
        {
            throw new CustomBasicException("Must specify a tactics name to be used since it may not be known at design time");
        }
        Value = "1.000"; //i think.
        base.Start();
    }
}