using BankServices.Bank.Containers.Operation;

namespace BankServices.Bank.Validators.ContainerValidation.Operation;

public interface IOperationContainerRemoveChecker
{
    public bool Check(Guid item, IOperationContainer container, out string message);
}