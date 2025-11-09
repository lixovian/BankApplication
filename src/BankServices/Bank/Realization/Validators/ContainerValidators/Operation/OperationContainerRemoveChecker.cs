using BankServices.Bank.Data.Containers.BankAccount;
using BankServices.Bank.Data.Containers.Operation;
using BankServices.Bank.Data.DataTransferObjects;
using BankServices.Bank.Data.Objects.Service;
using BankServices.Bank.Realization.BalanceCalculator;

namespace BankServices.Bank.Realization.Validators.ContainerValidators.Operation;

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