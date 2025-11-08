using BankServices.Bank.DataTransferObjects;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Patterns.Strategies.Analytics;
using BankServices.Patterns.Strategies.Analytics.CategoryGroup;
using BankServices.Patterns.Strategies.Analytics.MoneyAmplitude;

namespace BankServices.Patterns.Facades;

public class AnalyticsFacade
{
    private readonly IMoneyAmplitudeHandler _amplitudeHandler;
    private readonly ICategoryGroupHandler _groupHandler;

    public AnalyticsFacade(IMoneyAmplitudeHandler amplitudeHandler, ICategoryGroupHandler groupHandler)
    {
        _amplitudeHandler = amplitudeHandler;
        _groupHandler = groupHandler;
    }

    public decimal CalculateTotalAmountByCategory(CategoryData? data)
    {
        return _groupHandler.Handle(data);
    }
    
    public decimal CalculateTotalAmountByDateRange(DateRangeData data)
    {
        return _amplitudeHandler.Handle(data);
    }
}