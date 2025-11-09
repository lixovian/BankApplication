using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.BalanceCalculator;

namespace BankServices.Bank.Realization.Analytics.Services.MoneyAmplitude;

public interface IMoneyAmplitudeAnalyticStrategy
{
    public decimal Calculate(DateTime from, DateTime to, IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}