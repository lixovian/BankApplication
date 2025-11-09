using System.Text;
using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Bank.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using ViewManagerLibrary;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Analytics;

public class CategoryAnalyticsView : View
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    
    public void SetLabel()
    {
        var formatter = Services.Get<FormatterFacade>();
        var categories = Services.Get<CategoryFacade>().GetCategories();

        StringBuilder builder = new StringBuilder();

        builder.AppendLine(formatter.FormatCategoryTotal(null));
        foreach (var categoryData in categories)
        {
            builder.AppendLine(formatter.FormatCategoryTotal(categoryData));
        }

        _infoLabel.SetLabel(builder.ToString());
    }
    
    public override void OnStart(object[] args)
    {
        IViewManager manager = Services.Get<IViewManager>();

        _infoLabel = new LabelUnit("label", "");
        SetLabel();
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
            }, true),
            new LabelUnit("title", "Доходы/расходы по категориям:"),
            _infoLabel
        ];
        _block = new UnitBlock("block", units);
        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _block.Update(key);
    }
}