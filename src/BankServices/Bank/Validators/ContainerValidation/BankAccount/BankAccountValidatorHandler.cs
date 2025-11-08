using BankServices.Bank.Containers.Operation;

namespace BankServices.Bank.Validators.ContainerValidation.BankAccount;

public class BankAccountValidatorHandler :   IBankAccountValidatorHandler
{
    private readonly IOperationContainer _container;
    private readonly IBankAccountRemoveChecker _removeChecker;

    public BankAccountValidatorHandler(IOperationContainer container, IBankAccountRemoveChecker removeChecker)
    {
        _container = container;
        _removeChecker = removeChecker;
    }

    public void Handle(Guid id)
    {
        if (!_removeChecker.Check(id, _container, out var message))
        {
            throw new ArgumentException(message);
        }
    }
}