namespace AOEOTechEditorLibrary.Interfaces;
public interface ISelectableTech  : ISelectable
{
    string Title { get; }
    string Description { get; }
}