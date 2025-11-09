using BankServices.Data.Objects.Service;

namespace BankServices.Data.DataTransferObjects;

public class BalanceCalculationData : IDataTransferObject
{
    public decimal Balance { get;private set; }
    public TransactionType TransactionType { get; private set; }
    
    public decimal Amount { get; private set; }

    public BalanceCalculationData(decimal balance, TransactionType transactionType, decimal amount)
    {
        Balance = balance;
        TransactionType = transactionType;
        Amount = amount;
    }
}