using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface IDeleteCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}