using BankServices.Data.DataTransferObjects.Operation;

namespace BankServices.Data.Containers.Operation;

public class OperationContainer :  IOperationContainer
{
    private readonly List<Objects.Operation> _data = new();
    
    public IList<OperationData> GetAccountOperations(Guid id)
    {
        return _data.Where(x => id == x.BankAccountId).ToList().Select(x => new OperationData(x)).ToList();
    }

    public IList<OperationData> GetCategoryOperations(Guid? id)
    {
        return _data.Where(x => id == x.CategoryId).ToList().Select(x => new OperationData(x)).ToList();
    }

    public void Add(Objects.Operation obj)
    {
        _data.Add(obj);
    }

    public void Remove(Guid id)
    {
        var obj = Get(id);

        _data.Remove(obj);
    }

    public IReadOnlyList<Objects.Operation> GetAll()
    {
        return _data;
    }

    public void Edit(Objects.Operation obj)
    {
        var index = _data.FindIndex(c => c.Id == obj.Id);
        _data[index] = obj;
    }

    public Objects.Operation Get(Guid id)
    {
        var obj = _data.FirstOrDefault(x => x.Id == id);
        if (obj == null)
        {
            throw new ArgumentException($"Не найдена операция");
        }
        return obj;
    }

    public OperationData GetData(Guid id)
    {
        var obj = Get(id);
        return new OperationData(obj);
    }

    public IList<OperationData> GetAllData()
    {
        return _data.Select(x => new OperationData(x)).ToList();
    }
}