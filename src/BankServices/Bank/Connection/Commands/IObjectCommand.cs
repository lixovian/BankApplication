using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.Commands;

public interface IObjectCommand<in TData> where TData : IDataTransferObject
{
    public void Execute(TData data);
}