using BankServices.Data.DataTransferObjects;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.BalanceCalculator;

namespace BankServices.Realization.Analytics.Services.CategoryGroup;

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