namespace GuiLibrary.Simple.Inputs;

public class PathInput : ValidInput
{
    private readonly bool _needsExisting;
    public PathInput(string id, string title = "", bool needsExisting = false, bool isRendering = true) : base(id, title, isRendering)
    {
        _needsExisting = needsExisting;
    }

    protected override bool IsValid()
    {
        return (_needsExisting && File.Exists(GetData())) 
               || (!_needsExisting && Directory.Exists(Path.GetDirectoryName(GetData())));
    }
}