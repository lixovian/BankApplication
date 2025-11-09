using BankServices.Data.Containers.Operation;

namespace BankServices.Realization.Validators.ContainerValidators.BankAccount;

public class BankAccountRemoveChecker : IBankAccountRemoveChecker
{
    public bool Check(Guid id, IOperationContainer container, out string message)
    {
        if (container.GetAccountOperations(id).Any())
        {
            message = "У аккаунта ещё есть операции";
            return false;
        }

        message = "";
        return true;
    }
}