using BankServices.Data.DataTransferObjects.Category;
using GuiLibrary.Simple.Choosers;

namespace BankApplication.Gui;

public class CategoryChooser : HiddenChooserUnit<Guid?>
{
    public CategoryChooser(string id, bool isRendering = true) : base(id, "Категория", null, null, isRendering)
    {
    }
    
    public void SetData(IList<CategoryData?> categories)
    {
        SetRealValues(categories.Select(c => c?.Id ?? null).ToArray());
        SetValues(categories.Select(c => c?.Name ?? "Без категории").ToArray());
    }
    
    public CategoryData? GetChosen(IList<CategoryData?> categories)
    {
        return GetRealValue() == null 
            ? null
            : categories.FirstOrDefault(x => x != null && x.Id == GetRealValue());
    }
}