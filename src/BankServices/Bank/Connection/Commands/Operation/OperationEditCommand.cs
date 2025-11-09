using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.Operation;

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