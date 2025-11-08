using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Mediators.Ui;

public interface IViewGetsCommandTime
{
    public void GetTime(CommandTimeData data);
}