namespace AOEOTechEditorLibrary.Prereqs;
public class TypeCountModel : BasicPrereqModel
{
    /// <summary>
    /// the values that was used in the tech files already was aliveState, "aliveState,buildingState", and anyState
    /// the aliveState,buildingState was used for the garden techs.
    /// anyState was used for pvp egyptian techs only
    /// the aliveState was most common especially for the wonder tech so if you lose it, the tech goes away
    /// </summary>
    public string State { get; set; } = "";
    /// <summary>
    /// refer to the TechConditionOperators for the possible values
    /// </summary>
    public string Operator { get; set; } = "";
    public string Unit { get; set; } = "";
    public int Count { get; set; }

    public override XElement GetElement()
    {
        if (Unit == "")
        {
            throw new CustomBasicException("Must have a unit");
        }
        if (Operator == "")
        {
            throw new CustomBasicException("Must have an operator");
        }
        if (Count == 0)
        {
            throw new CustomBasicException("Must have a count");
        }
        string data = $"""
            <TypeCount unit="{Unit}" count="{Count}.0000" state="{State}" operator="{Operator}"/>
            """;
        return XElement.Parse(data);
    }
    protected internal override void Populate(Dictionary<string, string> values)
    {
        State = values["State"];
        Operator = values["Operator"];
        Unit = values["Unit"];
        Count = int.Parse(values["Count"]);
    }
    protected override string PrivateGetSerializedString()
    {
        return $"Tag: {nameof(TypeCountModel)} State:  {State} Unit:  {Unit}  Operator:  {Operator}  Count:  {Count}";
    }
}