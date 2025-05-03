namespace AOEOTechEditorLibrary.Prereqs;
public class TechStatusActiveModel(string techName) : BasicPrereqModel
{
    public override XElement GetElement()
    {
        string data = $"""
            <TechStatus status="Active">{techName}</TechStatus>
            """;
        return XElement.Parse(data);
    }
    protected override string PrivateGetSerializedString()
    {
        return $"Tag: {nameof(TechStatusActiveModel)} TechStatus:  Active,TechName:  {techName}";
    }
}