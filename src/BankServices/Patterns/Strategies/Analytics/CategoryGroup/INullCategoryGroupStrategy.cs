using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Strategies.BalanceCalculator;

namespace BankServices.Patterns.Strategies.Analytics.CategoryGroup;

public interface INullCategoryGroupStrategy
{
    public decimal Calculate(IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}