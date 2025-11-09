using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.Operation;

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