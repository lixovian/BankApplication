using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Mediators;

public interface ICommandTimeMediator
{
    public void Notify(CommandTimeData data);
}