using BankServices.Data.DataTransferObjects;
using BankServices.Data.Objects.Service;

namespace BankServices.Realization.BalanceCalculator;

public class BalanceCalculationStrategy : IBalanceCalculationStrategy
{
    public decimal Calculate(BalanceCalculationData data)
    {
        return data.Balance + (data.TransactionType == TransactionType.Income ? 1 : -1) * data.Amount;
    }
}