using BankServices.Bank.Data.DataTransferObjects;
using BankServices.Bank.Realization.BalanceCalculator;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Realization.Analytics.Services.MoneyAmplitude;

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