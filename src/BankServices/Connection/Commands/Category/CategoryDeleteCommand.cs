using BankServices.Data.DataTransferObjects.Category;
using BankServices.Realization.DomainFacades;

namespace BankServices.Connection.Commands.Category;

public class CategoryDeleteCommand : IDeleteCommand<CategoryIdentifierData>
{
    readonly CategoryFacade _facade;
    public CategoryDeleteCommand(CategoryFacade facade)
    {
        _facade = facade;
    }
    
    public void Execute(CategoryIdentifierData data)
    {
        _facade.DeleteCategory(data);
    }
}