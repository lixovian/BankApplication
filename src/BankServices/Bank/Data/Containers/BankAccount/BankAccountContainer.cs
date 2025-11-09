using BankServices.Bank.Data.DataTransferObjects.BankAccount;

namespace BankServices.Bank.Data.Containers.BankAccount;

public class BankAccountContainer : IBankAccountContainer
{
    private readonly List<Objects.BankAccount> _data = new();

    public void Add(Objects.BankAccount obj)
    {
        _data.Add(obj);
    }

    public void Remove(Guid id)
    {
        var obj = Get(id);
        
        _data.Remove(obj);
    }

    public IReadOnlyList<Objects.BankAccount> GetAll()
    {
        return _data;
    }

    public void Edit(Objects.BankAccount obj)
    {
        var index = _data.FindIndex(c => c.Id == obj.Id);

        if (index == -1)
        {
            throw new ArgumentException("Нет такого аккаунта");
        }
        
        _data[index] = obj;
    }

    public Objects.BankAccount Get(Guid id)
    {
        var obj = _data.FirstOrDefault(x => x.Id == id);
        if (obj == null)
        {
            throw new ArgumentException("Не найден аккаунт");
        }
        return obj;
    }

    public BankAccountData GetData(Guid id)
    {
        var obj = Get(id);
        return new BankAccountData(obj);
    }

    public IList<BankAccountData> GetAllData()
    {
        return _data.Select(x => new BankAccountData(x)).ToList();
    }
}