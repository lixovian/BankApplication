using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.CommandMediators;

public interface ICommandTimeMediator
{
    public void Notify(CommandTimeData data);
}