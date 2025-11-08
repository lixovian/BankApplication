using System.Text.Json.Serialization;

namespace BankServices.Bank.DataTransferObjects.BankAccount;

public class BankAccountData : IDataTransferObject
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Balance { get; private set; }

    [JsonConstructor]
    public BankAccountData(Guid id, string name, decimal balance)
    {
        Id = id;
        Name = name;
        Balance = balance;
    }

    public BankAccountData(Objects.BankAccount data)
    {
        Id = data.Id;
        Name = data.Name;
        Balance = data.Balance;
    }
}