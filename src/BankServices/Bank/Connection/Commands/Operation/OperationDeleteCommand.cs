using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.Operation;

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