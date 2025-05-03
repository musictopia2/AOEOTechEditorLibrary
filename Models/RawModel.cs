namespace AOEOTechEditorLibrary.Models;
public class RawModel : BasicEffectModel
{
    public string CustomAction { get; set; } = "";
    public string CustomSubType { get; set; } = "";
    public string CustomUnitType { get; set; } = "";
    public string CustomResource { get; set; } = "";
    public string CustomDamageType { get; set; } = "";
    public string CustomEffectType { get; set; } = "";
    public string CustomTargetType { get; set; } = "";
    public string CustomStatus { get; set; } = "";
    public string CustomScaling { get; set; } = "0.0000";
    protected override string Action => CustomAction;
    protected override string SubType => CustomSubType;
    protected override string UnitType => CustomUnitType;
    protected override string Resource => CustomResource;
    protected override string DamageType => CustomDamageType;
    protected override string EffectType => CustomEffectType;
    protected override string TargetType => CustomTargetType;
    protected override string Status => CustomStatus;
    protected override string Scaling => CustomScaling;
    // Static method to create RawModel from XML
    
}