using BankServices.Data.DataTransferObjects;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Realization.Analytics.Services.CategoryGroup;
using BankServices.Realization.Analytics.Services.MoneyAmplitude;

namespace BankServices.Realization.Analytics;

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