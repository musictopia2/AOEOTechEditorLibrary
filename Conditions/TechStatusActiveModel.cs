namespace AOEOTechEditorLibrary.Conditions;
public class TechStatusActiveModel(string techName) : BasicPrereqModel
{
    public override XElement GetElement()
    {
        string data = $"""
            <TechStatus status="Active">{techName}</TechStatus>
            """;
        return XElement.Parse(data);
    }
}