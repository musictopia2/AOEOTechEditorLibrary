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
        Dictionary<string, string> pairs = [];
        pairs.Add("Tag", nameof(TechStatusActiveModel));
        pairs.Add("TechStatus", "Active");
        pairs.Add("TechName", techName);
        return kk1.Serialize(pairs);
    }
}