namespace AOEOTechEditorLibrary.Conditions;
public class SpecificAgeModel(int age) : BasicPrereqModel
{
    public override XElement GetElement()
    {
        int real = age - 1;
        string data = $"""
            <SpecificAge>Age{real}</SpecificAge>
            """;
        return XElement.Parse(data);
    }
}