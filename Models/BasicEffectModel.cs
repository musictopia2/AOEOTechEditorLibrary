namespace AOEOTechEditorLibrary.Models;
public abstract class BasicEffectModel
{
    public string ProtoUnit { get; set; } = "";
    protected abstract string Action { get; }
    protected abstract string SubType { get; }
    protected abstract string Relativity { get; }
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
        output.SetAttributeValue("scaling", "0.0000");
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
}