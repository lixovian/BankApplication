using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Patterns.Facades;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Patterns.Strategies.Analytics.CategoryGroup;

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