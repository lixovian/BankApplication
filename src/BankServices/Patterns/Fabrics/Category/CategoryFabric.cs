using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.Category;

namespace BankServices.Patterns.Fabrics.Category;

public class CategoryFabric : IObjectFabric<Objects.Category, CategoryRequiredData>
{
    private readonly ICategoryChecker _checker;

    public CategoryFabric(ICategoryChecker checker)
    {
        _checker = checker;
    }

    public Objects.Category Create(CategoryRequiredData data)
    {
        var obj = new Objects.Category(Guid.NewGuid(), data.Type, data.Name);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}