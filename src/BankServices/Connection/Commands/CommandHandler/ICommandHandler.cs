using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Commands.CommandHandler;

public interface ICommandHandler
{
    public void Handle<TData>(IObjectCommand<TData> command, TData data) where TData : IDataTransferObject;
}