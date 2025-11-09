using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.CommandMediators.Ui;

public interface IViewGetsCommandTime
{
    public void GetTime(CommandTimeData data);
}