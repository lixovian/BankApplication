using BankServices.Data.DataTransferObjects;

namespace BankServices.Realization.DomainFabrics;

public interface IObjectFabric<T, in TData> where TData : IDataTransferObject
{
    public T Create(TData data);
}