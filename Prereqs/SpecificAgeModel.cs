namespace AOEOTechEditorLibrary.Prereqs;
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
    protected override string PrivateGetSerializedString()
    {
        Dictionary<string, string> pairs = [];
        pairs.Add("Tag", nameof(SpecificAgeModel));
        pairs.Add("Age", age.ToString());
        return kk1.Serialize(pairs);
    }
}