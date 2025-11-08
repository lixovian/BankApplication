using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Patterns.Strategies.Analytics.MoneyAmplitude;

public interface IMoneyAmplitudeAnalyticStrategy
{
    public decimal Calculate(DateTime from, DateTime to, IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}