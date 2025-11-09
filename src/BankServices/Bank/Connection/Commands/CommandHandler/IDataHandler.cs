using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.Commands.CommandHandler;

public interface IDataHandler<TIn> where TIn : IDataTransferObject
{
    public void Handle(TIn input);
}