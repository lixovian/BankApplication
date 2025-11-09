using BankServices.Bank.Data.DataTransferObjects;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.BalanceCalculator;

namespace BankServices.Bank.Realization.Analytics.Services.CategoryGroup;

public class ValueCategoryGroupStrategy : IValueCategoryGroupStrategy
{
    public decimal Calculate(Guid categoryId, IList<OperationData> operations, IBalanceCalculationStrategy strategy)
    {
        decimal result = 0;
            
        foreach (var op in operations.Where(x => x.CategoryId == categoryId))
        {
            result = strategy.Calculate(new BalanceCalculationData(result, op.Type, op.Amount));
        }

        return Math.Abs(result);
    }
}