using BankServices.Bank.Containers.Operation;

namespace BankServices.Bank.Validators.ContainerValidation.BankAccount;

public interface IBankAccountRemoveChecker
{
    public bool Check(Guid id, IOperationContainer container, out string message);
}