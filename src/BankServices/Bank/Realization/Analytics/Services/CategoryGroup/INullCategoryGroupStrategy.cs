using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.BalanceCalculator;

namespace BankServices.Bank.Realization.Analytics.Services.CategoryGroup;

public interface INullCategoryGroupStrategy
{
    public decimal Calculate(IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}