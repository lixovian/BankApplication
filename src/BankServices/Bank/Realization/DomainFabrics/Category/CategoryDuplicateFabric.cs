using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Realization.Validators.DataValidators.Category;

namespace BankServices.Bank.Realization.DomainFabrics.Category;

public class CategoryDuplicateFabric : IObjectFabric<Data.Objects.Category, CategoryDuplicateData>
{
    private readonly ICategoryChecker _checker;

    public CategoryDuplicateFabric(ICategoryChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.Category Create(CategoryDuplicateData data)
    {
        var obj = new Data.Objects.Category(data.Main.Id, data.Main.Type, data.NewName);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}