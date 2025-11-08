using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Facades;

namespace BankServices.Connection.Commands.Operation;

public class OperationEditCommand : IEditCommand<OperationEditData>
{
    readonly OperationFacade _facade;
    public OperationEditCommand(OperationFacade facade)
    {
        _facade = facade;
    }
    
    public void Execute(OperationEditData data)
    {
        _facade.EditOperation(data);
    }
}