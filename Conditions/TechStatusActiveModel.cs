namespace AOEOTechEditorLibrary.Conditions;
public class TechStatusActiveModel(string techName) : BasicPrereqModel
{
    required
    public string TechName { get; set; } = techName;
    public override XElement GetElement()
    {
        string data = $"""
            <TechStatus status="Active">{TechName}</TechStatus>
            """;
        return XElement.Parse(data);
    }
}