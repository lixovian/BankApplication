namespace GuiLibrary.Simple.Choosers;

public class HiddenChooserUnit<TData> : StringChooserUnit
{
    private TData[] _realValues;
    
    public HiddenChooserUnit(string id, string title, TData[]? realValues = null, string[]? values = null, bool isRendering = true) : base(id, title, values, isRendering)
    {
        _realValues = realValues ?? [];
    }

    public TData? GetRealValue()
    {
            return _realValues.Length <= _chosenValue ? default : _realValues[_chosenValue];
    }

    public void SetRealValues(TData[] realValues)
    {
        _realValues = realValues;
    }
    
    public void SetActiveValue(TData realValue)
    {
        if (_realValues.Length == 0)
        {
            return;
        }
        
        var index = -1;
        for (var i = 0; i < _realValues.Length; i++)
        {
            if ((realValue == null && _realValues[i] != null) || (realValue != null && !realValue.Equals(_realValues[i])))
            {
                continue;
            }
            
            index = i;
            break;
        }

        if (index == -1)
        {
            throw new ArgumentException("Указанный объект не найден");
        }
        
        SetValueIndex(index);
    }
}