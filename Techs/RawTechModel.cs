namespace AOEOTechEditorLibrary.Techs;
public class RawTechModel : BasicTechModel
{
    public BasicList<string> Flags { get; set; } = [];
    public string CustomStatus { get; set; } = "";
    public bool CustomGlobal { get; set; }
    protected override string Status => CustomStatus;
    public override bool Global => CustomGlobal;
    protected override BasicList<string> GetFlags()
    {
        return Flags.ToBasicList();
    }
}