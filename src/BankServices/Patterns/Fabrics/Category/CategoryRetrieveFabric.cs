using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.Category;

namespace BankServices.Patterns.Fabrics.Category;

public class CategoryRetrieveFabric : IObjectFabric<Objects.Category, CategoryData>
{
    private readonly ICategoryChecker _checker;

    public CategoryRetrieveFabric(ICategoryChecker checker)
    {
        _checker = checker;
    }

    public Objects.Category Create(CategoryData data)
    {
        var obj = new Objects.Category(data.Id, data.Type, data.Name);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}