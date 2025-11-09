using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.Category;

public class CategoryEditCommand : IEditCommand<CategoryEditData>
{
    readonly CategoryFacade _facade;
    public CategoryEditCommand(CategoryFacade facade)
    {
        _facade = facade;
    }
    
    public void Execute(CategoryEditData data)
    {
        _facade.EditCategory(data);
    }
}