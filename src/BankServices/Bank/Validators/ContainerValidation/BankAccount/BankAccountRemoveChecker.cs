using BankServices.Bank.Containers.Operation;

namespace BankServices.Bank.Validators.ContainerValidation.BankAccount;

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