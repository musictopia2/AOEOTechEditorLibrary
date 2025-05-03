namespace AOEOTechEditorLibrary.Prereqs;
public class TechStatusUnobtainableModel(string techName) : BasicPrereqModel
{
    public override XElement GetElement()
    {
        string data = $"""
            <TechStatus status="Unobtainable">{techName}</TechStatus>
            """;
        return XElement.Parse(data);
    }
    protected override string PrivateGetSerializedString()
    {
        return $"Tag: {nameof(TechStatusUnobtainableModel)} TechStatus:  Unobtainable,  TechName:  {techName}";
    }
}