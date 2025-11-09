using BankServices.Bank.Connection.CommandMediators.Ui;
using BankServices.Bank.Data.DataTransferObjects;
using ViewManagerLibrary.ViewManager;

namespace BankServices.Bank.Connection.CommandMediators;

public class CommandTimeMediator : ICommandTimeMediator
{
    private readonly IViewManager _viewManager;

    public CommandTimeMediator(IViewManager viewManager)
    {
        _viewManager = viewManager;
    }

    public void Notify(CommandTimeData data)
    {
        var view = _viewManager.GetCurrent();

        if (view is IViewGetsCommandTime time)
        {
            time.GetTime(data);
        }
    }
}