namespace AOEOTechEditorLibrary.Helpers;
public static class PrereqsServices
{
    public static BasicList<XElement> GetPrereqs(BasicList<BasicPrereqModel> prereqs)
    {
        BasicList<XElement> output = [];
        foreach (BasicPrereqModel prereq in prereqs)
        {
            XElement xml = prereq.GetElement();
            output.Add(xml);
        }
        return output;
    }
}