namespace AOEOTechEditorLibrary.Services;
public class TechNameService
{
    private readonly Dictionary<string, int> _counters = new();
    public string GetNext(string prefix)
    {
        int count = _counters.TryGetValue(prefix, out var current) ? current + 1 : 1;
        _counters[prefix] = count;
        return $"{prefix}{count}";
    }
}