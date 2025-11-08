using BankServices.Bank.DataTransferObjects.Category;

namespace BankServices.Patterns.Strategies.Analytics.CategoryGroup;

public interface ICategoryGroupHandler
{
    public decimal Handle(CategoryData? category);
}