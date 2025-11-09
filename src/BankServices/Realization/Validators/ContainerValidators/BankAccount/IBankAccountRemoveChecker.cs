using BankServices.Data.Containers.Operation;

namespace BankServices.Realization.Validators.ContainerValidators.BankAccount;

public interface IBankAccountRemoveChecker
{
    public bool Check(Guid id, IOperationContainer container, out string message);
}