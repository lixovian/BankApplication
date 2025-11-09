using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.Category;

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