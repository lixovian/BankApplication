using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Bank.Data.DataTransferObjects;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Analytics;

public class DateAnalyticsView : View
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private ValueInput<DateTime> _from = null!;
    private ValueInput<DateTime> _to = null!;


    private void OnClick()
    {
        var formatter = Services.Get<FormatterFacade>();

        if (!_from.GetConvertedValue(out DateTime from) ||
            !_to.GetConvertedValue(out DateTime to))
        {
            return;
        } 
        
        _infoLabel.SetLabel(formatter.FormatAmplitudeTotal(new DateRangeData(from, to)));
    }
    
    public override void OnStart(object[] args)
    {
        IViewManager manager = Services.Get<IViewManager>();

        _infoLabel = new LabelUnit("label", "");
        _from = new ValueInput<DateTime>("from", "От");
        _to = new ValueInput<DateTime>("to", "До");
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
                new ButtonUnit("do", "Получить данные", OnClick), 
            }, true),
            new LabelUnit("title", "Аналитика по диапазону дат:"),
            _from,
            _to,
            _infoLabel,
        ];
        _block = new UnitBlock("block", units);
        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _block.Update(key);
    }
}