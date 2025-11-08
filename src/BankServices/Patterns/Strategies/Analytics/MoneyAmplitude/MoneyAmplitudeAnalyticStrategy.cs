using BankServices.Bank.DataTransferObjects;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Patterns.Strategies.Analytics.MoneyAmplitude;

public class MoneyAmplitudeAnalyticStrategy : IMoneyAmplitudeAnalyticStrategy
{
    public decimal Calculate(DateTime from, DateTime to, IList<OperationData> operations, IBalanceCalculationStrategy strategy)
    {
        decimal result = 0;

        foreach (var op in operations.Where(x => x.Date >= from && x.Date <= to))
        {
            result = strategy.Calculate(new BalanceCalculationData(result, op.Type, op.Amount));
        }
        
        return result;
    }
}