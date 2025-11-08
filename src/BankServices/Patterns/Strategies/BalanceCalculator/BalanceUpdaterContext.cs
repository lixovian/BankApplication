using BankServices.Bank.DataTransferObjects;
using BankServices.Objects;

namespace BankServices.Patterns.Strategies.BalanceCalculator;

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