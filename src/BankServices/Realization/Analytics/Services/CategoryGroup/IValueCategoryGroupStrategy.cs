using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.BalanceCalculator;

namespace BankServices.Realization.Analytics.Services.CategoryGroup;

public interface IValueCategoryGroupStrategy
{
    public decimal Calculate(Guid categoryId, IList<OperationData> operations, IBalanceCalculationStrategy strategy);
}