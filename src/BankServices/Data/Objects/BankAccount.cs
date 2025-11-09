namespace BankServices.Data.Objects;

public class BankAccount
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Balance { get; set; }

    public BankAccount(Guid id, string name, decimal balance)
    {
        Id = id;
        Name = name;
        
        Balance = balance;
    }
}