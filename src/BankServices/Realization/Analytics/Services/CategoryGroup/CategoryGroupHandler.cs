using BankServices.Data.DataTransferObjects.Category;
using BankServices.Realization.BalanceCalculator;
using BankServices.Realization.DomainFacades;

namespace BankServices.Realization.Analytics.Services.CategoryGroup;

public class CategoryGroupHandler : ICategoryGroupHandler
{
    private readonly INullCategoryGroupStrategy _nullCategoryGroupGroupStrategy;
    private readonly IValueCategoryGroupStrategy _valueCategoryGroupGroupStrategy;
    
    private readonly IBalanceCalculationStrategy _balanceCalculationStrategy;
    
    private readonly OperationFacade _operationFacade;

    public CategoryGroupHandler(INullCategoryGroupStrategy nullCategoryGroupGroupStrategy, IValueCategoryGroupStrategy valueCategoryGroupGroupStrategy, OperationFacade operationFacade, IBalanceCalculationStrategy balanceCalculationStrategy)
    {
        _nullCategoryGroupGroupStrategy = nullCategoryGroupGroupStrategy;
        _valueCategoryGroupGroupStrategy = valueCategoryGroupGroupStrategy;
        _operationFacade = operationFacade;
        _balanceCalculationStrategy = balanceCalculationStrategy;
    }

    public decimal Handle(CategoryData? category)
    {
        var operations = _operationFacade.GetOperations();

        if (category == null)
        {
            return _nullCategoryGroupGroupStrategy.Calculate(operations, _balanceCalculationStrategy);
        }
        
        return _valueCategoryGroupGroupStrategy.Calculate(category.Id, operations, _balanceCalculationStrategy);
    }
}