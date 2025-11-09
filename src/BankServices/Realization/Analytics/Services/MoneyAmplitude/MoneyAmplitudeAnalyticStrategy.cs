using BankServices.Data.DataTransferObjects;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.BalanceCalculator;

namespace BankServices.Realization.Analytics.Services.MoneyAmplitude;

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