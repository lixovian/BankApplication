using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.Commands;

public interface IDeleteCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}