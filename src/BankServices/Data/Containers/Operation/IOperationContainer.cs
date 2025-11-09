using BankServices.Data.DataTransferObjects.Operation;

namespace BankServices.Data.Containers.Operation;

public interface IOperationContainer
{
    public IList<OperationData> GetAccountOperations(Guid id);
    public IList<OperationData> GetCategoryOperations(Guid? id);

    public void Add(Objects.Operation obj);

    public void Remove(Guid id);

    public IReadOnlyList<Objects.Operation> GetAll();

    public void Edit(Objects.Operation obj);

    public Objects.Operation Get(Guid id);

    public OperationData GetData(Guid id);

    public IList<OperationData> GetAllData();
}