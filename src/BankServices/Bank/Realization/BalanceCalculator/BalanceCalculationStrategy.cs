using BankServices.Bank.Data.DataTransferObjects;
using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Realization.BalanceCalculator;

public class BalanceCalculationStrategy : IBalanceCalculationStrategy
{
    public decimal Calculate(BalanceCalculationData data)
    {
        return data.Balance + (data.TransactionType == TransactionType.Income ? 1 : -1) * data.Amount;
    }
}