using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.CommandMediators;

public interface ICommandTimeMediator
{
    public void Notify(CommandTimeData data);
}