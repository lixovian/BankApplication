using BankServices.Bank.DataTransferObjects.BankAccount;

namespace BankServices.Bank.Containers.BankAccount;

public interface IBankAccountContainer
{
    public void Add(Objects.BankAccount obj);

    public void Remove(Guid id);

    public IReadOnlyList<Objects.BankAccount> GetAll();

    public void Edit(Objects.BankAccount obj);

    public Objects.BankAccount Get(Guid id);

    public BankAccountData GetData(Guid id);

    public IList<BankAccountData> GetAllData();
}