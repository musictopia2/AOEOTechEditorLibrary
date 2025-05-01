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
    public static XElement StartNewTech(string name)
    {
        return StartNewTech(name, []);
    }
    public static XElement StartNewTech(string name, BasicList<BasicPrereqModel> conditions)
    {
        string source = $"""
            <Tech name = "{name}" type = "Normal">
                <DBID>5128</DBID>
                <DisplayNameID>-1</DisplayNameID>
                <ResearchPoints>0.0000</ResearchPoints>
                <Status>UNOBTAINABLE</Status>
                <RolloverTextID>-1</RolloverTextID>
                <ContentPack>18</ContentPack>
                <Flag>IsAward</Flag>
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
    public static BasicList<XElement> GetPrereqs(this XElement tech)
    {
        BasicList<XElement> output = tech.Element("Prereqs")!.Elements().ToBasicList();
        BasicList<XElement> temp = output.ToBasicList();
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