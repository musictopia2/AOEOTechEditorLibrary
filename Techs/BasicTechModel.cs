namespace AOEOTechEditorLibrary.Techs;
public class BasicTechModel
{
    public string Name { get; set; } = "";
    public BasicList<BasicPrereqModel> Prereqs { get; set; } = [];
    public BasicList<BasicEffectModel> Effects { get; set; } = [];
    protected virtual string Status { get;} = "UNOBTAINABLE";
    public int DBID { get; set; } = 5128;
    public string DisplayNameID { get; set; } = "-1";
    public string ResearchPoints { get; set; } = "0.0000";
    public string RolloverTextID { get; set; } = "-1";
    public string ContentPack { get; set; } = "18";
    public string Icon { get; set; } = "";
    public virtual bool Global { get; } = false;
    public static BasicTechModel? CreateFromXml(XElement element)
    {
        if (element.Name.LocalName != "Tech")
        {
            return null;
        }

        // Default to RawTechModel so we can handle flags/status flexibly
        var model = new RawTechModel
        {
            Name = element.Attribute("name")?.Value ?? "",
            CustomStatus = element.Element("Status")?.Value ?? "UNOBTAINABLE",
            DBID = int.TryParse(element.Element("DBID")?.Value, out var dbid) ? dbid : 0,
            DisplayNameID = element.Element("DisplayNameID")?.Value ?? "-1",
            ResearchPoints = element.Element("ResearchPoints")?.Value ?? "0.0000",
            RolloverTextID = element.Element("RolloverTextID")?.Value ?? "-1",
            ContentPack = element.Element("ContentPack")?.Value ?? "18",
            Icon = element.Element("Icon")?.Value ?? ""
        };

        // Load Flags
        foreach (var flag in element.Elements("Flag"))
        {
            model.Flags.Add(flag.Value);
        }

        // Load Costs
        foreach (var cost in element.Elements("Cost"))
        {
            var resourceStr = cost.Attribute("resourcetype")?.Value;
            var value = cost.Value;

            if (Enum.TryParse<EnumResource>(resourceStr, out var resourceEnum))
            {
                CostModel temp = new(resourceEnum, value);
                model.Costs.Add(temp);
            }
            else
            {
                // Optional: handle unknown resource types (log, throw, or ignore)
                throw new CustomBasicException($"Unknown resource type: {resourceStr}");
            }
        }

        // Load Prereqs
        var prereqElement = element.Element("Prereqs");
        if (prereqElement is not null)
        {
            foreach (var child in prereqElement.Elements())
            {
                var prereq = BasicPrereqModel.CreateFromXml(child);
                model.Prereqs.Add(prereq);
            }
        }

        // Load Effects
        var effectElement = element.Element("Effects");
        if (effectElement is not null)
        {
            foreach (var child in effectElement.Elements())
            {
                var effect = BasicEffectModel.CreateFromXml(child);
                if (effect is not null)
                {
                    model.Effects.Add(effect);
                }
            }
        }

        return model;
    }
    protected virtual BasicList<string> GetFlags()
    {
        if (Prereqs.Count > 0)
        {
            return ["Volatile"];
        }
        return ["IsAward"];
    }
    public BasicList<CostModel> Costs { get; set; } = [];

    //the xml will always show normal for type.  period.
    protected virtual void Start()
    {
        //if not populated, will default to some things.
        if (DBID == 0)
        {
            DBID = 5128;
        }
        if (string.IsNullOrWhiteSpace(DisplayNameID))
        {
            DisplayNameID = "-1";
        }
        if (string.IsNullOrWhiteSpace(ResearchPoints))
        {
            ResearchPoints = "0.0000";
        }
        if (string.IsNullOrEmpty(RolloverTextID))
        {
            RolloverTextID = "-1";
        }
        if (GetFlags().Count == 0)
        {
            throw new CustomBasicException("I think should have at least one flag");
        }
    }
    public XElement GetElement()
    {
        Start();
        string source = $"""
            <Tech name="{Name}" type="Normal">
                <DBID>{DBID}</DBID>
                <DisplayNameID>{DisplayNameID}</DisplayNameID>
                <ResearchPoints>{ResearchPoints}</ResearchPoints>
                <RolloverTextID>{RolloverTextID}</RolloverTextID>
                <ContentPack>{ContentPack}</ContentPack>
                <Icon>{Icon}</Icon>
                <Status>{Status}</Status>
            </Tech>
            """;
        var flags = GetFlags();
        XElement output = XElement.Parse(source);
        foreach (var item in flags)
        {
            XElement flagElement = new ("Flag", item);
            output.Add(flagElement);
        }
        foreach (var item in Costs)
        {
            // Create an XElement for the Cost element directly
            XElement costElement = new ("Cost",
                new XAttribute("resourcetype", item.Resource),
                item.Value);

            // Add the Cost element to the output
            output.Add(costElement);
        }
        // Add Prereqs if they exist
        if (Prereqs.Count > 0)
        {
            XElement prereqsElement = new ("Prereqs");
            foreach (var prereq in Prereqs)
            {
                prereqsElement.Add(prereq.GetElement());
            }
            output.Add(prereqsElement);
        }
        if (Effects.Count > 0)
        {
            XElement effectElement = new("Effects");
            foreach (var item in Effects)
            {
                effectElement.Add(item.GetElement());
            }
            output.Add(effectElement);
        }
        return output;
    }

    public override string ToString()
    {
        var dict = new Dictionary<string, string>
    {
        { "Name", Name },
        { "DBID", DBID.ToString() },
        { "DisplayNameID", DisplayNameID },
        { "ResearchPoints", ResearchPoints },
        { "RolloverTextID", RolloverTextID },
        { "ContentPack", ContentPack },
        { "Icon", Icon },
        { "Status", Status },
        { "Flags", string.Join(",", GetFlags()) }
    };

        for (int i = 0; i < Costs.Count; i++)
        {
            dict[$"Costs[{i}].Resource"] = Costs[i].Resource.ToString();
            dict[$"Costs[{i}].Value"] = Costs[i].Value;
        }

        for (int i = 0; i < Prereqs.Count; i++)
        {
            dict[$"Prereqs[{i}]"] = Prereqs[i].ToString(); // already serializes correctly
        }

        for (int i = 0; i < Effects.Count; i++)
        {
            dict[$"Effects[{i}]"] = Effects[i].ToString(); // already serializes correctly
        }

        return string.Join(Environment.NewLine, dict.Select(kvp => $"{kvp.Key}={kvp.Value}"));
    }
    public static BasicTechModel CreateFromString(string input)
    {
        var lines = input.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
        var dict = lines.Select(line =>
        {
            var parts = line.Split('=', 2);
            if (parts.Length != 2)
            {
                throw new CustomBasicException($"Invalid line format: {line}");
            }

            return new KeyValuePair<string, string>(parts[0], parts[1]);
        }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        var model = new RawTechModel
        {
            Name = dict["Name"],
            DBID = int.Parse(dict["DBID"]),
            DisplayNameID = dict["DisplayNameID"],
            ResearchPoints = dict["ResearchPoints"],
            RolloverTextID = dict["RolloverTextID"],
            ContentPack = dict["ContentPack"],
            Icon = dict["Icon"],
            CustomStatus = dict["Status"]
        };

        if (dict.TryGetValue("Flags", out var flags))
        {
            model.Flags = flags.Split(',').Select(x => x.Trim()).ToBasicList();
        }

        // Parse costs
        var costGroups = dict
            .Where(kvp => kvp.Key.StartsWith("Costs["))
            .GroupBy(kvp => kvp.Key.Substring(0, kvp.Key.IndexOf(']') + 1)) // group by Costs[0], Costs[1], etc.
            .ToList();
        foreach (var group in costGroups)
        {
            string resource = group.FirstOrDefault(x => x.Key.EndsWith(".Resource")).Value;
            string value = group.FirstOrDefault(x => x.Key.EndsWith(".Value")).Value;

            if (!Enum.TryParse(resource, out EnumResource enumRes))
            {
                throw new CustomBasicException($"Invalid resource type: {resource}");
            }

            model.Costs.Add(new CostModel(enumRes, value));
        }

        // Parse Prereqs
        var prereqs = dict
            .Where(kvp => kvp.Key.StartsWith("Prereqs["))
            .OrderBy(kvp => kvp.Key)
            .Select(kvp => BasicPrereqModel.CreateFromString(kvp.Value));
        model.Prereqs.AddRange(prereqs);

        // Parse Effects
        var effects = dict
            .Where(kvp => kvp.Key.StartsWith("Effects["))
            .OrderBy(kvp => kvp.Key)
            .Select(kvp => BasicEffectModel.CreateFromString(kvp.Value));
        model.Effects.AddRange(effects);
        return model;
    }
}