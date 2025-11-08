using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Patterns.Strategies.Analytics.CategoryGroup;

public interface IValueCategoryGroupStrategy
{
    public decimal Calculate(Guid categoryId, IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}