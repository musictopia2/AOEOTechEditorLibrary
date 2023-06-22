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
        return ourxml;
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
        string startString = """
            <TechTree version="1">
            </TechTree>
            """;
        XElement techs = XElement.Parse(startString);
        XElement ourxml = StartNewTech(techName);
        XElement effects = GetEffects(list);
        ourxml.Add(effects);
        techs.Add(ourxml);
        return techs;
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
    //public static BasicList<XElement> GetEditedElements(this XElement tech, BasicList<TechValuePairModel> pairs)
    //{
    //    BasicList<XElement> output = tech.Element("Effects")!.Elements().ToBasicList();
    //    BasicList<XElement> temp = output.ToBasicList();
    //    foreach (var item in temp)
    //    {
    //        if (CanUseTech(item) == false)
    //        {
    //            output.RemoveSpecificItem(item); //i think
    //        }
    //    }
    //    foreach (var item in output)
    //    {
    //        if (item.IsProperEffectElement())
    //        {
    //            var fins = item.Attribute("amount");
    //            if (fins is not null)
    //            {
    //                string value = fins.Value;
    //                foreach (var pair in pairs)
    //                {
    //                    if (pair.OriginalValue == value)
    //                    {
    //                        fins.Value = pair.ModifiedValue;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    return output;
    //}
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
    //internal static bool IsProperEffectElement(this XElement source)
    //{
    //    var item = source.Attribute("subtype");
    //    if (item is null)
    //    {
    //        return false;
    //    }
    //    if (source.Attribute("subtype")!.Value == "ActionEnable")
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}