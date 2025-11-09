using BankServices.Data.DataTransferObjects;
using BankServices.Data.Objects;

namespace BankServices.Realization.BalanceCalculator;

public class BalanceUpdaterContext : IBalanceUpdaterContext
{
    private readonly IBalanceCalculationStrategy _balanceCalculationStrategy;

    public BalanceUpdaterContext(IBalanceCalculationStrategy balanceCalculationStrategy)
    {
        _balanceCalculationStrategy = balanceCalculationStrategy;
    }

    public void Update(BankAccount account, Operation op)
    {
        account.Balance = _balanceCalculationStrategy.Calculate(
            new BalanceCalculationData(account.Balance, op.Type, op.Amount));
    }
}