using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.DomainFacades;

namespace BankServices.Realization.Observers.CategoryObserver.Subscribers;

public class OperationContainerUpdater:ICategoryUpdateSubscriber
{
    private readonly OperationFacade _operationFacade;

    public OperationContainerUpdater(OperationFacade operationFacade)
    {
        _operationFacade = operationFacade;
    }

    public void Notify(Guid removed)
    {
        foreach (var operation in _operationFacade.GetOperations())
        {
            if (operation.CategoryId == removed)
            {
                _operationFacade.EditOperation(new OperationEditData(operation.Id, operation.Description, null));
            }
        }
    }
}