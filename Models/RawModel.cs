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
    public static BasicEffectModel? CreateFromXml(XElement element)
    {
        if (element.Name != "Effect")
        {
            return null;
        }

        var rawModel = new RawModel
        {
            CustomEffectType = element.Attribute("type")?.Value ?? "",
            CustomScaling = element.Attribute("scaling")?.Value ?? "0.0000",
            Value = element.Attribute("amount")?.Value ?? "",
            CustomAction = element.Attribute("action")?.Value ?? "",
            CustomSubType = element.Attribute("subtype")?.Value ?? "",
            CustomDamageType = element.Attribute("damagetype")?.Value ?? "",
            CustomUnitType = element.Attribute("unittype")?.Value ?? "",
            CustomResource = element.Attribute("resource")?.Value ?? "",
            Relativity = element.Attribute("relativity")?.Value ?? "",
            CustomTargetType = element.Element("Target")?.Attribute("type")?.Value ?? "",
            CustomStatus = element.Attribute("status")?.Value ?? ""
        };
        // Handle the <Target> element
        XElement? targetElement = element.Element("Target");
        if (targetElement != null)
        {
            rawModel.CustomTargetType = targetElement.Attribute("type")?.Value ?? "";

            // If it has a value (inner text), determine what it is
            string innerText = targetElement.Value?.Trim() ?? "";

            if (!string.IsNullOrEmpty(innerText))
            {
                // Heuristic: if target type is set and it's clearly a unit, assign to ProtoUnit
                // Otherwise, treat it as Content
                rawModel.ProtoUnit = innerText;
            }

            // Edge case: if there's content but it's not a ProtoUnit, you might need more rules
            // You can adjust this logic based on what types of content you expect
        }

        // If element.Value exists and there's no <Target> child, set it as Content
        if (!element.Elements("Target").Any() && !string.IsNullOrWhiteSpace(element.Value))
        {
            rawModel.Content = element.Value.Trim();
        }

        return rawModel;
    }
}