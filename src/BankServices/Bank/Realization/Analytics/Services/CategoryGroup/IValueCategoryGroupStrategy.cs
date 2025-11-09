using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.BalanceCalculator;

namespace BankServices.Bank.Realization.Analytics.Services.CategoryGroup;

public interface IValueCategoryGroupStrategy
{
    public decimal Calculate(Guid categoryId, IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}