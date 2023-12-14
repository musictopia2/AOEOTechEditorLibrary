namespace AOEOTechEditorLibrary.Interfaces;
public interface ISelectableTech //still need this just in case we need to choose different advisors, milestones.
{
    bool DidChoose { get; set; }
    string Title { get; }
    string Description { get; }
}