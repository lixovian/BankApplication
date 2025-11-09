using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Realization.DomainFabrics;

public interface IObjectFabric<T, in TData> where TData : IDataTransferObject
{
    public T Create(TData data);
}