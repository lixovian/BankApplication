using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Data.DataTransferObjects.Operation;

public class OperationRequiredData : IDataTransferObject
{
    public TransactionType Type { get; private set; }
    public Guid BankAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public string Description { get; private set; }
    public Guid? CategoryId { get; private set; }
    
    public OperationRequiredData(Objects.Operation data)
    {
        Type = data.Type;
        BankAccountId = data.BankAccountId;
        Amount = data.Amount;
        Description = data.Description;
        CategoryId = data.CategoryId;
    }

    public OperationRequiredData(TransactionType type, Guid bankAccountId, decimal amount, string description, Guid? categoryId)
    {
        Type = type;
        BankAccountId = bankAccountId;
        Amount = amount;
        Description = description;
        CategoryId = categoryId;
    }
}