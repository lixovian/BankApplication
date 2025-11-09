using BankServices.Bank.Data.DataTransferObjects.Category;

namespace BankServices.Bank.Realization.Analytics.Services.CategoryGroup;

public interface ICategoryGroupHandler
{
    public decimal Handle(CategoryData? category);
}