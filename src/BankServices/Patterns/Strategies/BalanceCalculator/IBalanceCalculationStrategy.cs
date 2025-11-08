using BankServices.Bank.DataTransferObjects;

namespace BankServices.Patterns.Strategies.BalanceCalculator;

public interface IBalanceCalculationStrategy
{
    public decimal Calculate(BalanceCalculationData data);
}