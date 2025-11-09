using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface ICreateCommand<in TData> : IObjectCommand<TData> where TData : IDataTransferObject
{
    
}