using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Facades;

namespace BankServices.Connection.Commands.Operation;

public class OperationCreateCommand : ICreateCommand<OperationRequiredData>
{
    readonly OperationFacade _facade;
    public OperationCreateCommand(OperationFacade facade)
    {
        _facade = facade;
    }

    public void Execute(OperationRequiredData requiredData)
    {
        _facade.CreateOperation(requiredData);
    }
}