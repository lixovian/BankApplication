using System.Text.Json.Serialization;
using BankServices.Objects.Service;

namespace BankServices.Bank.DataTransferObjects.Operation;

public class OperationData : IDataTransferObject
{
    public Guid Id { get; private set; }
    public TransactionType Type { get; private set; }
    public Guid BankAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Guid? CategoryId { get; private set; }
    
    public OperationData(Objects.Operation data)
    {
        Id = data.Id;
        Type = data.Type;
        BankAccountId = data.BankAccountId;
        Amount = data.Amount;
        Date = data.Date;
        Description = data.Description;
        CategoryId = data.CategoryId;
    }

    [JsonConstructor]
    public OperationData(Guid id, TransactionType type, Guid bankAccountId, decimal amount, DateTime date, string description, Guid? categoryId)
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