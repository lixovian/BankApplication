using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Realization.BalanceCalculator;

public interface IBalanceCalculationStrategy
{
    public decimal Calculate(BalanceCalculationData data);
}