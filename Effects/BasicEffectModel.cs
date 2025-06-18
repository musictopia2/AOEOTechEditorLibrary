namespace AOEOTechEditorLibrary.Effects;
public abstract class BasicEffectModel
{
    public string ProtoUnit { get; set; } = "";
    protected abstract string Action { get; }
    protected abstract string SubType { get; }
    protected virtual string Scaling { get; } = "0.0000";
    public virtual string Relativity { get; set; } = "";
    public string Value { get; set; } = "";
    protected abstract string UnitType { get; }
    protected abstract string Resource { get; }
    protected abstract string DamageType { get; }
    protected abstract string EffectType { get; }
    protected abstract string TargetType { get; }
    protected abstract string Status { get; }
    public string Content { get; set; } = "";
    private bool NeedsAllActions()
    {
        if (SubType == "Damage")
        {
            return true;
        }
        if (SubType == "DamageBonus")
        {
            return true;
        }
        return false; //so far.
    }
    protected virtual void Start()
    {

    }
    public XElement GetElement()
    {
        Start(); //so if some rules was accidently not followed, will follow.
        string source = """
            <Effect>
            </Effect>
            """;
        XElement output = XElement.Parse(source);
        output.SetAttributeValue("type", EffectType);
        if (Action != "")
        {
            output.SetAttributeValue("action", Action);
        }
        if (Value != "")
        {
            output.SetAttributeValue("amount", Value);
        }
        output.SetAttributeValue("scaling", Scaling);
        if (SubType != "")
        {
            output.SetAttributeValue("subtype", SubType);
        }
        if (DamageType != "")
        {
            output.SetAttributeValue("damagetype", DamageType);
        }
        if (UnitType != "")
        {
            output.SetAttributeValue("unittype", UnitType);
        }
        if (Resource != "")
        {
            output.SetAttributeValue("resource", Resource);
        }
        if (NeedsAllActions())
        {
            output.SetAttributeValue("allactions", "1");
        }
        if (Relativity != "")
        {
            output.SetAttributeValue("relativity", Relativity);
        }
        if (Status != "")
        {
            output.SetAttributeValue("status", Status);
        }
        if (Content != "" && TargetType == "")
        {
            output.Value = Content;
        }
        else if (TargetType != "")
        {
            if (ProtoUnit != "")
            {
                source = $"""
                    <Target type="{TargetType}">{ProtoUnit}</Target>
                    """;
            }
            else if (Content == "")
            {
                source = $"""
                    <Target type="{TargetType}" />
                    """;
            }
            else
            {
                source = $"""
                    <Target type="{TargetType}">{Content}</Target>
                    """;
            }
            XElement target = XElement.Parse(source);
            output.Add(target);
        }
        else
        {
            throw new CustomBasicException("Must either have content or target type");
        }
        return output;
    }
    public static BasicList<BasicEffectModel> DeserializeRawModels(XElement effectsElement)
    {
        // Using LINQ to select and filter the models in one go
        return [.. effectsElement.Elements("Effect")
                .Select(CreateFromXml)  // Apply CreateFromXml
                .Where(model => model != null)  // Filter out any null models
                .Cast<BasicEffectModel>()];
    }
    public static BasicEffectModel? CreateFromXml(XElement element)
    {
        if (element.Name != "Effect")
        {
            return null;
        }
        var rawModel = new RawEffectModel
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

    // Override ToString method to return human-readable string representation
    public override string ToString()
    {
        Start(); //try this first in case it has to populate something else first.
        Dictionary<string, string> values = [];
        values.Add("Effect Type", EffectType);
        values.Add("Action", Action);
        values.Add("SubType", SubType);
        values.Add("Value", Value);
        values.Add("Scaling", Scaling);
        values.Add("ProtoUnit", ProtoUnit);
        values.Add("UnitType", UnitType);
        values.Add("Resource", Resource);
        values.Add("DamageType", DamageType);
        values.Add("Relativity", Relativity);
        values.Add("TargetType", TargetType);
        values.Add("Status", Status);
        values.Add("Content", Content);
        return kk1.Serialize(values);
    }
    public static BasicEffectModel CreateFromString(string modelString)
    {
        var rawModel = new RawEffectModel();

        // Deserialize the modelString into a dictionary
        Dictionary<string, string> values = kk1.Deserialize(modelString);
        var keyMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "Effect Type", "Effect Type" },
        { "Type", "Effect Type" }, // alias
        { "Action", "Action" },
        { "SubType", "SubType" },
        { "Value", "Value" },
        { "Scaling", "Scaling" },
        { "ProtoUnit", "ProtoUnit" },
        { "UnitType", "UnitType" },
        { "Resource", "Resource" },
        { "DamageType", "DamageType" },
        { "Relativity", "Relativity" },
        { "TargetType", "TargetType" },
        { "Status", "Status" },
        { "Content", "Content" }
    };
        // Loop through the dictionary and set the corresponding property of rawModel
        foreach (var property in values)
        {
            var key = property.Key.Trim();    // The property name (e.g., "Effect Type")
            var value = property.Value.Trim(); // The value associated with the property (e.g., "SomeEffect")

            if (!keyMap.TryGetValue(key, out var normalizedKey))
            {
                throw new FormatException($"Unknown property '{key}' in string: {modelString}");
            }

            // Depending on the key, set the corresponding property
            switch (normalizedKey)
            {
                case "Effect Type":
                    rawModel.CustomEffectType = value;
                    break;
                case "Action":
                    rawModel.CustomAction = value;
                    break;
                case "SubType":
                    rawModel.CustomSubType = value;
                    break;
                case "Value":
                    rawModel.Value = value;
                    break;
                case "Scaling":
                    rawModel.CustomScaling = value;
                    break;
                case "ProtoUnit":
                    rawModel.ProtoUnit = value;
                    break;
                case "UnitType":
                    rawModel.CustomUnitType = value;
                    break;
                case "Resource":
                    rawModel.CustomResource = value;
                    break;
                case "DamageType":
                    rawModel.CustomDamageType = value;
                    break;
                case "Relativity":
                    rawModel.Relativity = value;
                    break;
                case "TargetType":
                    rawModel.CustomTargetType = value;
                    break;
                case "Status":
                    rawModel.CustomStatus = value;
                    break;
                case "Content":
                    rawModel.Content = value;
                    break;
                default:
                    throw new FormatException($"Unknown property '{key}' in string: {modelString}");
            }
        }

        return rawModel;
    }
}