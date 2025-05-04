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
        Dictionary<string, string> pairs = [];
        pairs.Add("Tag", nameof(TechStatusUnobtainableModel));
        pairs.Add("TechStatus", "Unobtainable");
        pairs.Add("TechName", techName);
        return kk1.Serialize(pairs);
    }
}