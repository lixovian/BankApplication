using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Realization.Validators.DataValidators.Category;

namespace BankServices.Bank.Realization.DomainFabrics.Category;

public class CategoryFabric : IObjectFabric<Data.Objects.Category, CategoryRequiredData>
{
    private readonly ICategoryChecker _checker;

    public CategoryFabric(ICategoryChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.Category Create(CategoryRequiredData data)
    {
        var obj = new Data.Objects.Category(Guid.NewGuid(), data.Type, data.Name);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}