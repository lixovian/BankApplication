using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.Commands.CommandHandler;

public interface ICommandHandler
{
    public void Handle<TData>(IObjectCommand<TData> command, TData data) where TData : IDataTransferObject;
}