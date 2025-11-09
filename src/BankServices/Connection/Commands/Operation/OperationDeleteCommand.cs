using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.DomainFacades;

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