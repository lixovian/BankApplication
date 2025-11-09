using BankServices.Data.Objects.Service;

namespace BankServices.Data.Objects;

public class Category
{
    public Guid Id { get; private set; }
    public TransactionType Type { get; private set; }
    public string Name { get; private set; }

    public Category(Guid id, TransactionType type, string name)
    {
        Id = id;
        Type = type;
        Name = name;
    }
}