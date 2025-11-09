using BankServices.Bank.Data.DataTransferObjects;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.BalanceCalculator;

namespace BankServices.Bank.Realization.Analytics.Services.MoneyAmplitude;

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