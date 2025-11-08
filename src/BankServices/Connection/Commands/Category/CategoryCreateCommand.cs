using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Patterns.Facades;

namespace BankServices.Connection.Commands.Category;

public class CategoryCreateCommand : ICreateCommand<CategoryRequiredData>
{
    readonly CategoryFacade _facade;
    public CategoryCreateCommand(CategoryFacade facade)
    {
        _facade = facade;
    }

    public void Execute(CategoryRequiredData requiredData)
    {
        _facade.CreateCategory(requiredData);
    }
}