namespace AOEOTechEditorLibrary.Helpers;
public static class TechTreeServices
{
    public static XElement StartTechTree()
    {
        string startString = """
            <TechTree version="1">
            </TechTree>
            """;
        XElement techs = XElement.Parse(startString);
        return techs;
    }
    private static int _id = 0;
    public static void Reset()
    {
        _id = 0; //i want to start with 1
    }
    //public static BasicList<BasicTechModel> LoadRawCompleteTechs()
    //{
    //    string path = dd1.RawTechLocation;
    //    XElement source = XElement.Load(path);
    //    var list = new BasicList<BasicTechModel>();
    //    foreach (var techElement in source.Elements("Tech"))
    //    {
    //        var model = BasicTechModel.CreateFromXml(techElement) ?? throw new CustomBasicException("Fail in parsing raw techs");
    //        list.Add(model);
    //    }
    //    Reset(); //this is when to reset it.
    //    return list;
    //}
    public static void SaveAdditionalTechsToGameFolder(BasicList<BasicTechModel> techs)
    {

        string path = dd1.RawTechLocation;
        XElement source = XElement.Load(path);


        // Create the root element
        //XElement root = new("TechTree");
        //root.SetAttributeValue("version", "1");

        // Add each tech's XML
        foreach (var tech in techs)
        {
            source.Add(tech.GetElement());
        }
        //if this breaks it, then rethink.
        //at least i can easily recover

        // Create XDocument with declaration
        //XDocument doc = new(
        //    new XDeclaration("1.0", "utf-8", "yes"),
        //    root
        //);

        // Save to file
        source.Save(dd1.NewTechLocation);
    }
    public static BasicTechModel CreateNewTechModel(bool isGlobal = false)
    {
        _id++;
        string name = $"CustomTech{_id}";
        return CreateNewTechModel(name, isGlobal);
    }
    public static BasicTechModel CreateNewTechModel(string name, bool isGlobal = false)
    {
        BasicTechModel output;
        if (isGlobal)
        {
            output = new GlobalTechModel();
        }
        else
        {
            output = new BasicTechModel();
        }
        output.Name = name;
        return output;
    }

    public static XElement StartNewTech(string name)
    {
        return StartNewTech(name, []);
    }
    public static XElement StartNewTech(string name, BasicList<BasicPrereqModel> conditions)
    {
        string flag;
        if (conditions.Count == 0)
        {
            flag = "IsAward";
        }
        else
        {

            flag = "Volatile";
        }
        string source = $"""
            <Tech name = "{name}" type = "Normal">
                <DBID>5128</DBID>
                <DisplayNameID>-1</DisplayNameID>
                <ResearchPoints>0.0000</ResearchPoints>
                <Status>UNOBTAINABLE</Status>
                <RolloverTextID>-1</RolloverTextID>
                <ContentPack>18</ContentPack>
                <Flag>{flag}</Flag>
            </Tech>
            """;
        XElement ourxml = XElement.Parse(source);
        if (conditions.Count > 0)
        {
            source = """
                <Prereqs>
                </Prereqs>
                """;
            XElement main = XElement.Parse(source);
            foreach (var item in conditions)
            {
                main.Add(item.GetElement());
            }
            ourxml.Add(main); //hopefully this simple.
        }
        return ourxml;
    }
    public static XElement GetPrereqs(BasicList<XElement> preqs)
    {
        string source = """
                <Prereqs>
                </Prereqs>
                """;
        XElement output = XElement.Parse(source);
        output.Add(preqs);
        return output;
    }
    public static XElement GetEffects(BasicList<XElement> effects)
    {
        string source = """
            <Effects>
            </Effects>
            """;
        XElement output = XElement.Parse(source);
        output.Add(effects);
        return output;
    }
    //this is for cases where you only have one tech for the entire file.
    public static XElement GetSimpleNewTechTreeWithSingleTech(BasicList<XElement> list, string techName)
    {
        return GetSimpleNewTechTreeWithSingleTech(list, techName, []);
    }
    public static XElement GetSimpleNewTechTreeWithSingleTech(BasicList<XElement> effects, string techName, BasicList<XElement> prepreqs)
    {
        string startString = """
            <TechTree version="1">
            </TechTree>
            """;
        XElement techs = XElement.Parse(startString);
        XElement ourxml = StartNewTech(techName);
        XElement other = GetEffects(effects);
        ourxml.Add(other);
        if (prepreqs.Count > 0)
        {
            other = GetPrereqs(prepreqs);
            ourxml.Add(other);
        }
        techs.Add(ourxml);
        return techs;
    }
    public static void AddTechsToTree(this XElement element, BasicList<BasicTechModel> techs)
    {
        foreach (var item in techs)
        {
            element.Add(item.GetElement());
        }
    }
    public static BasicList<XElement> GetPrereqs(this XElement tech)
    {
        BasicList<XElement> output = tech.Element("Prereqs")!.Elements().ToBasicList();
        return output;
    }
    public static BasicList<XElement> GetEffects(this XElement tech)
    {
        //reserve the possibility of no techvaluepairs.
        BasicList<XElement> output = tech.Element("Effects")!.Elements().ToBasicList();
        BasicList<XElement> temp = output.ToBasicList();
        foreach (var item in temp)
        {
            if (CanUseTech(item) == false)
            {
                output.RemoveSpecificItem(item); //i think
            }
        } //this case just gets the efects of the tech element and takes into account no deer for the advisor still.
        return output;
    }
    private static bool CanUseTech(XElement effect)
    {
        var item = effect.Attribute("action");
        if (item is null)
        {
            return true;
        }
        if (item.Value == "SpawnDeer_E")
        {
            return false;
        }
        return true;
    }
}