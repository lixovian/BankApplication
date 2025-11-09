using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.Commands.CommandHandler;

public class CommandHandler : ICommandHandler
{
    public void Handle<TData>(IObjectCommand<TData> command, TData data) where TData : IDataTransferObject
    {
        command.Execute(data);
    }
}