using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.Commands.CommandHandler;

public interface IDataHandler<TIn> where TIn : IDataTransferObject
{
    public void Handle(TIn input);
}