namespace AOEOTechEditorLibrary.Techs;
public class CostModel(EnumResource resource, string value)
{
    public EnumResource Resource { get; set; } = resource;
    public string Value { get; set; } = value;
}