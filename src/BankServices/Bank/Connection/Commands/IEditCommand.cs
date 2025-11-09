using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Connection.Commands;

public interface IEditCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}