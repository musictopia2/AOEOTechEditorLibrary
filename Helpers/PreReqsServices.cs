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

    public static BasicList<BasicPrereqModel> GetPreqs(XElement prereqsElement)
    {
        BasicList<BasicPrereqModel> prereqs = [];
        if (prereqsElement == null)
        {
            return prereqs;
        }
        foreach (var element in prereqsElement.Elements())
        {
            try
            {
                var model = BasicPrereqModel.CreateFromXml(element);
                prereqs.Add(model);
            }
            catch (Exception ex)
            {
                // You can decide how you want to log or handle this
                throw new CustomBasicException($"Failed to parse prereq: {element}", ex);
            }
        }

        return prereqs;
    }

    // Convert list of prerequisites to a text string
    public static string GetPrereqsText(BasicList<BasicPrereqModel> prereqs)
    {
        BasicList<string> prereqsStrings = [];
        foreach (var prereq in prereqs)
        {
            prereqsStrings.Add(prereq.ToString());
        }
        return string.Join("\n", prereqsStrings);
    }

    // Convert text string back to list of prerequisites
    public static BasicList<BasicPrereqModel> GetPrereqsFromText(string prereqsText)
    {
        BasicList<BasicPrereqModel> prereqs = [];

        if (string.IsNullOrEmpty(prereqsText))
        {
            return prereqs;
        }

        var lines = prereqsText.Split('\n');
        foreach (var line in lines)
        {
            // Ensure we handle empty lines gracefully
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            try
            {
                var prereq = BasicPrereqModel.CreateFromString(line);
                prereqs.Add(prereq);
            }
            catch (Exception ex)
            {
                throw new CustomBasicException($"Failed to parse prerequisite: {line}", ex);
            }
        }
        return prereqs;
    }
}