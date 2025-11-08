using BankServices.Objects;

namespace BankServices.Patterns.Strategies.BalanceCalculator;

public interface IBalanceUpdaterContext
{
    public void Update(BankAccount account, Operation op);
}