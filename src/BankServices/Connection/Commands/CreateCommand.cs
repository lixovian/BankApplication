using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface ICreateCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}