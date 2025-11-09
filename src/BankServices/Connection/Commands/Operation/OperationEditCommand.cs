using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.DomainFacades;

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