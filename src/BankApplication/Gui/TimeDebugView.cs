using BankServices.Bank.Connection.CommandMediators.Ui;
using BankServices.Bank.Data.DataTransferObjects;
using GuiLibrary.Simple;
using ViewManagerLibrary;

namespace BankApplication.Gui;

public class TimeDebugView : View, IViewGetsCommandTime
{
    protected LabelUnit _debug = null!;

    public override void OnStart(object[] args)
    {
        _debug = new LabelUnit("time", "");
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _debug.SetLabel("");
    }

    public void GetTime(CommandTimeData data)
    {
            _debug.SetLabel($"--Задача выполнена за {data.Elapsed.Microseconds} мкс--");
    }
}