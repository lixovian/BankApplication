using BankServices.Data.DataTransferObjects;
using BankServices.Realization.BalanceCalculator;
using BankServices.Realization.DomainFacades;

namespace BankServices.Realization.Analytics.Services.MoneyAmplitude;

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