using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.Category;

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