namespace GuiLibrary.Simple.Inputs;

public class DecimalInput : InputUnit
{
    public DecimalInput(string id, string title = "", bool isRendering = true) : base(id, title, isRendering)
    {
    }

    public bool GetConvertedValue(out decimal value)
    {
        return Decimal.TryParse(GetData(), out value);
    }
    
    protected override void SetUpHighlight(bool doHighlight)
    {
        if (doHighlight)
        {
            if (GetConvertedValue(out decimal _))
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