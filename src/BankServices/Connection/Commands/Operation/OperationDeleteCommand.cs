using BankServices.Bank.DataTransferObjects;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Facades;

namespace BankServices.Connection.Commands.Operation;

public class OperationDeleteCommand : IDeleteCommand<OperationIdentifierData>
{
    readonly OperationFacade _facade;
    public OperationDeleteCommand(OperationFacade facade)
    {
        _facade = facade;
    }
    
    public void Execute(OperationIdentifierData data)
    {
        _facade.DeleteOperation(data);
    }
}