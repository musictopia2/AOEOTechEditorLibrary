namespace AOEOTechEditorLibrary.Techs;
public class RawTechModel : BasicTechModel
{
    public BasicList<string> Flags { get; set; } = [];
    public string CustomStatus { get; set; } = "";
    protected override string Status => CustomStatus;
    protected override BasicList<string> GetFlags()
    {
        return Flags.ToBasicList();
    }
}