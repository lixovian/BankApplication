namespace BankServices.Bank.DataTransferObjects.BankAccount;

public class BankAccountEditData : IDataTransferObject
{
    public BankAccountEditData(Objects.BankAccount data)
    {
        Id = data.Id;
        Name = data.Name;
    }

    public BankAccountEditData(string name, Guid id)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
}