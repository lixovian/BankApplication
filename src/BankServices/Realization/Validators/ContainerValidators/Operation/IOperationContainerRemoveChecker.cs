using BankServices.Data.Containers.Operation;

namespace BankServices.Realization.Validators.ContainerValidators.Operation;

public interface IOperationContainerRemoveChecker
{
    public bool Check(Guid item, IOperationContainer container, out string message);
}