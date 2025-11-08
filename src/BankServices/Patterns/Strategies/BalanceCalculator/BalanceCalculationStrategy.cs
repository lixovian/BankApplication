using BankServices.Bank.DataTransferObjects;
using BankServices.Objects.Service;

namespace BankServices.Patterns.Strategies.BalanceCalculator;

public class BalanceCalculationStrategy : IBalanceCalculationStrategy
{
    public decimal Calculate(BalanceCalculationData data)
    {
        return data.Balance + (data.TransactionType == TransactionType.Income ? 1 : -1) * data.Amount;
    }
}