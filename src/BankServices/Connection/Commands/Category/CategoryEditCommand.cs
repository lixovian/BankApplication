using BankServices.Data.DataTransferObjects.Category;
using BankServices.Realization.DomainFacades;

namespace BankServices.Connection.Commands.Category;

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