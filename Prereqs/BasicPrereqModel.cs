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
    }
}