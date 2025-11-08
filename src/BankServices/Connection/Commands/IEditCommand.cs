using BankServices.Bank.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface IEditCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}