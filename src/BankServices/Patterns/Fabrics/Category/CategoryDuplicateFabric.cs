using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.Category;

namespace BankServices.Patterns.Fabrics.Category;

public class CategoryDuplicateFabric : IObjectFabric<Objects.Category, CategoryDuplicateData>
{
    private readonly ICategoryChecker _checker;

    public CategoryDuplicateFabric(ICategoryChecker checker)
    {
        _checker = checker;
    }

    public Objects.Category Create(CategoryDuplicateData data)
    {
        var obj = new Objects.Category(data.Main.Id, data.Main.Type, data.NewName);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}