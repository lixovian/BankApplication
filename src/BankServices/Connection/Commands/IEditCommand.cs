using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface IEditCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}