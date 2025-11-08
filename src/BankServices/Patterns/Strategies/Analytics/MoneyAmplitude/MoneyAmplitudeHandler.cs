using BankServices.Bank.DataTransferObjects;
using BankServices.Patterns.Facades;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Patterns.Strategies.Analytics.MoneyAmplitude;

public class MoneyAmplitudeHandler : IMoneyAmplitudeHandler
{
    private readonly OperationFacade _operationFacade;
    private readonly IBalanceCalculationStrategy _balanceCalculationStrategy;
    
    private readonly IMoneyAmplitudeAnalyticStrategy _amplitudeAnalyticStrategy;

    public MoneyAmplitudeHandler(OperationFacade operationFacade, IBalanceCalculationStrategy balanceCalculationStrategy, IMoneyAmplitudeAnalyticStrategy amplitudeAnalyticStrategy)
    {
        _operationFacade = operationFacade;
        _balanceCalculationStrategy = balanceCalculationStrategy;
        _amplitudeAnalyticStrategy = amplitudeAnalyticStrategy;
    }

    public decimal Handle(DateRangeData data)
    {
        var operations = _operationFacade.GetOperations();
        return _amplitudeAnalyticStrategy.Calculate(data.From, data.To, operations, _balanceCalculationStrategy);
    }
}