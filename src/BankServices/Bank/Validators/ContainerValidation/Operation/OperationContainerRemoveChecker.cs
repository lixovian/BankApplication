using BankServices.Bank.Containers.BankAccount;
using BankServices.Bank.Containers.Operation;
using BankServices.Bank.DataTransferObjects;
using BankServices.Objects.Service;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Bank.Validators.ContainerValidation.Operation;

public class OperationContainerRemoveChecker : IOperationContainerRemoveChecker
{
    private readonly IBalanceCalculationStrategy _balanceCalculationStrategy;
    private readonly IBankAccountContainer _container;

    public OperationContainerRemoveChecker(IBankAccountContainer container,
        IBalanceCalculationStrategy balanceCalculationStrategy)
    {
        _container = container;  
        _balanceCalculationStrategy = balanceCalculationStrategy;
    }

    public bool Check(Guid item, IOperationContainer container, out string message)
    {
        var operation = container.GetData(item);
        
        try
        {
            var account = _container.GetData(operation.BankAccountId);
            if (_balanceCalculationStrategy.Calculate(new BalanceCalculationData(account.Balance,
                    operation.Type == TransactionType.Income ? TransactionType.Expense : TransactionType.Income,
                    operation.Amount)) < 0)
            {
                message = "При удалении баланс станет отрицательным";
                return false;
            }
        }
        catch (ArgumentException e)
        {
            message = e.Message;
            return false;
        }

        message = "";
        return true;
    }
}