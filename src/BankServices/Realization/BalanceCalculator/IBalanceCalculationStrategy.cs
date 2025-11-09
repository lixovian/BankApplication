using BankServices.Data.DataTransferObjects;

namespace BankServices.Realization.BalanceCalculator;

public interface IBalanceCalculationStrategy
{
    public decimal Calculate(BalanceCalculationData data);
}