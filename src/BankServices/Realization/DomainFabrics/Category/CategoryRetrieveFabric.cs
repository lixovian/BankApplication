using BankServices.Data.DataTransferObjects.Category;
using BankServices.Realization.Validators.DataValidators.Category;

namespace BankServices.Realization.DomainFabrics.Category;

public class CategoryRetrieveFabric : IObjectFabric<Data.Objects.Category, CategoryData>
{
    private readonly ICategoryChecker _checker;

    public CategoryRetrieveFabric(ICategoryChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.Category Create(CategoryData data)
    {
        var obj = new Data.Objects.Category(data.Id, data.Type, data.Name);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}