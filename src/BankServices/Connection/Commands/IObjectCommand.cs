using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface IObjectCommand<in TData> where TData : IDataTransferObject
{
    public void Execute(TData data);
}