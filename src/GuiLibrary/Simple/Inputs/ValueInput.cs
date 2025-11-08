using System.ComponentModel;

namespace GuiLibrary.Simple.Inputs;

public class ValueInput<T> : ValidInput
{
    public ValueInput(string id, string title = "", bool isRendering = true) : base(id, title, isRendering)
    {
    }

    public bool GetConvertedValue(out T? value)
    {
        try
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            // Cast ConvertFromString(string text) : object to (T)
            value = (T)converter.ConvertFromString(GetData())!;
            return true;
        }
        catch (NotSupportedException)
        {
            value = default;
            return false;
        }
        catch (ArgumentException)
        {
            value = default;
            return false;
        }
        catch (FormatException)
        {
            value = default;
            return false;
        }
    }

    protected override bool IsValid()
    {
        return GetConvertedValue(out _);
    }
}