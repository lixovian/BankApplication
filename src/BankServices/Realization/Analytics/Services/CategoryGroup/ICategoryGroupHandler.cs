using BankServices.Data.DataTransferObjects.Category;

namespace BankServices.Realization.Analytics.Services.CategoryGroup;

public interface ICategoryGroupHandler
{
    public decimal Handle(CategoryData? category);
}