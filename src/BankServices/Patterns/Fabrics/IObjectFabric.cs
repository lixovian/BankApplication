using BankServices.Bank.DataTransferObjects;

namespace BankServices.Patterns.Fabrics;

public interface IObjectFabric<T, in TData> where TData : IDataTransferObject
{
    public T Create(TData data);
}