using BankServices.Data.Containers.BankAccount;
using BankServices.Data.Containers.Category;
using BankServices.Data.DataTransferObjects;
using BankServices.Realization.BalanceCalculator;

namespace BankServices.Realization.Validators.ContainerValidators.Operation;

public class OperationContainerAddChecker : IOperationContainerAddChecker
{
    private readonly IBankAccountContainer _bankAccountContainer;
    private readonly ICategoryContainer _categoryContainer;
    
    private readonly IBalanceCalculationStrategy _balanceCalculationStrategy;
    
    public OperationContainerAddChecker(IBalanceCalculationStrategy balanceCalculationStrategy, IBankAccountContainer bankAccountContainer, ICategoryContainer categoryContainer)
    {
        _balanceCalculationStrategy = balanceCalculationStrategy;
        _bankAccountContainer = bankAccountContainer;
        _categoryContainer = categoryContainer;
    }

    public bool Check(Data.Objects.Operation item, out string message)
    {
        try
        {
            var account = _bankAccountContainer.GetData(item.BankAccountId);
            if (_balanceCalculationStrategy.Calculate(new BalanceCalculationData(account.Balance, item.Type, item.Amount)) < 0)
            {
                message = "Недостаточно денег на счёте";
                return false;
            }
        }
        catch (ArgumentException e)
        {
            message = e.Message;
            return false;
        }
        
        if (item.CategoryId.HasValue)
        {
            try
            {
                var category = _categoryContainer.GetData(item.CategoryId.Value);
                
                if (category.Type != item.Type)
                {
                    message = "Не совпадает тип транзакций категории и операции";
                    return false;
                }
            }
            catch (ArgumentException e)
            {
                message = e.Message;
                return false;
            }
        }

        message = "";
        return true;
    }
}