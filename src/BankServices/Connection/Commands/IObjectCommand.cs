using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.Commands;

public interface IObjectCommand<in TData> where TData : IDataTransferObject
{
    public void Execute(TData data);
}