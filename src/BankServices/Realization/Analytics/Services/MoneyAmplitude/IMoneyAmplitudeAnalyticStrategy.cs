using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.BalanceCalculator;

namespace BankServices.Realization.Analytics.Services.MoneyAmplitude;

public interface IMoneyAmplitudeAnalyticStrategy
{
    public decimal Calculate(DateTime from, DateTime to, IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}