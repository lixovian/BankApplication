namespace GuiLibrary.Simple.Inputs;

public abstract class ValidInput : InputUnit
{
    protected ValidInput(string id, string title = "", bool isRendering = true) : base(id, title, isRendering)
    {
    }

    protected abstract bool IsValid();
    
    protected override void SetUpHighlight(bool doHighlight)
    {
        if (doHighlight)
        {
            if (IsValid())
            {
                Highlight(Config.DefaultRightForegroundColor, Config.DefaultRightBackgroundColor);
            }
            else
            {
                Highlight(Config.DefaultWrongForegroundColor, Config.DefaultWrongBackgroundColor);
            }
        }
        else
        {
            Highlight(Config.DefaultInputForegroundColor, Config.DefaultInputBackgroundColor);
        }
    }
}