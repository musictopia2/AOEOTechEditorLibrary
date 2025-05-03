namespace AOEOTechEditorLibrary.Prereqs;
public abstract class BasicPrereqModel
{
    public abstract XElement GetElement();
    protected abstract string PrivateGetSerializedString();
    protected internal virtual void Populate(Dictionary<string, string> values)
    {
        //default with nothing.
    }
    public override string ToString()
    {
        string value = PrivateGetSerializedString();
        return value;
    }
    public static BasicPrereqModel CreateFromXml(XElement element)
    {
        string tagName = element.Name.LocalName;

        if (PrereqModelFactory.XmlRegistry.TryGetValue(tagName, out var factory))
        {
            return factory(element);
        }

        throw new CustomBasicException($"Unsupported XML prereq tag: {tagName}");
    }

    public static BasicPrereqModel CreateFromString(string input)
    {

        var values = kk1.Deserialize(input);
        var tag = values["Tag"];
        return PrereqModelFactory.Create(tag, values);

        //Dictionary<string, string> values = kk1.Deserialize(input);
        //string used = values["Tag"];
        //string tech;
        //BasicPrereqModel output;
        //if (used == nameof(SpecificAgeModel))
        //{
        //    string partAge = values["Age"];
        //    int realAge = int.Parse(partAge);
        //    output = new SpecificAgeModel(realAge);
        //    output.Populate(values); //this needs to finish up.
        //    return output;
        //}
        //if (used == nameof(TechStatusActiveModel))
        //{
        //    tech = values["TechName"];
        //    output = new TechStatusActiveModel(tech);
        //    output.Populate(values);
        //    return output;
        //}
        //if (used == nameof(TechStatusUnobtainableModel))
        //{
        //    tech = values["TechName"];
        //    output = new TechStatusUnobtainableModel(tech);
        //    output.Populate(values);
        //    return output;
        //}
        //if (used == nameof(TypeCountModel))
        //{
        //    output = new TypeCountModel();
        //    output.Populate(values);
        //    return output;
        //}
        //throw new CustomBasicException($"No prereq supported for {used}");
    }
}