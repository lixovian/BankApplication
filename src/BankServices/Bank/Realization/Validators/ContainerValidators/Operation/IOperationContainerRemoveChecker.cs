using BankServices.Bank.Data.Containers.Operation;

namespace BankServices.Bank.Realization.Validators.ContainerValidators.Operation;

public interface IOperationContainerRemoveChecker
{
    public bool Check(Guid item, IOperationContainer container, out string message);
}