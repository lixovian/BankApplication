using BankServices.Data.Objects.Service;

namespace BankServices.Data.Objects;

public class Operation
{
    public Guid Id { get; private set; }
    public TransactionType Type { get; private set; }
    public Guid BankAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Guid? CategoryId { get; private set; }

    public Operation(
        Guid id,
        TransactionType type,
        Guid bankAccountId,
        decimal amount,
        DateTime date,
        string description,
        Guid? categoryId)
    {
        Id = id;
        Type = type;
        BankAccountId = bankAccountId;
        Amount = amount;
        Date = date;
        Description = description;
        CategoryId = categoryId;
    }
}