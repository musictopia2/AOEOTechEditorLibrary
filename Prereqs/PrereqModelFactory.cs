namespace AOEOTechEditorLibrary.Prereqs;
public class PrereqModelFactory
{
    private static readonly Dictionary<string, Func<Dictionary<string, string>, BasicPrereqModel>> _registry
       = new()
   {
        {
            nameof(SpecificAgeModel),
            dict => new SpecificAgeModel(int.Parse(dict["Age"]))
        },
        {
            nameof(TechStatusActiveModel),
            dict => new TechStatusActiveModel(dict["TechName"])
        },
        {
            nameof(TechStatusUnobtainableModel),
            dict => new TechStatusUnobtainableModel(dict["TechName"])
        },
        {
            nameof(TypeCountModel),
            dict => {
                var model = new TypeCountModel();
                model.Populate(dict);
                return model;
            }
        }
   };

    public static BasicPrereqModel Create(string tag, Dictionary<string, string> values)
    {
        if (_registry.TryGetValue(tag, out var factory))
        {
            var model = factory(values);
            model.Populate(values); // Optional if already done inside factory
            return model;
        }

        throw new CustomBasicException($"Unsupported prereq tag: {tag}");
    }


    internal static readonly Dictionary<string, Func<XElement, BasicPrereqModel>> XmlRegistry
       = new()
   {
        {
            "TechStatus",
            element =>
            {
                var status = element.Attribute("status")?.Value ?? throw new CustomBasicException("Missing status");
                var name = element.Value;
                return status switch
                {
                    "Active" => new TechStatusActiveModel(name),
                    "Unobtainable" => new TechStatusUnobtainableModel(name),
                    _ => throw new CustomBasicException($"Unsupported TechStatus value: {status}")
                };
            }
        },
        {
            "SpecificAge",
            element =>
            {
                var text = element.Value;
                if (text.StartsWith("Age") && int.TryParse(text[3..], out int age))
                {
                    return new SpecificAgeModel(age + 1); // Add 1 because internal format subtracts
                }
                throw new CustomBasicException("Invalid SpecificAge format.");
            }
        },
        {
            "TypeCount",
            element =>
            {
                return new TypeCountModel
                {
                    Unit = element.Attribute("unit")?.Value ?? throw new CustomBasicException("Missing unit"),
                    Operator = element.Attribute("operator")?.Value ?? throw new CustomBasicException("Missing operator"),
                    State = element.Attribute("state")?.Value ?? "", // Optional
                    Count = int.TryParse(element.Attribute("count")?.Value?.Split('.')[0], out int c) ? c : throw new CustomBasicException("Invalid count")
                };
            }
        }
   };
    
    

}