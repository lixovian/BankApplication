using BankServices.Data.Objects;

namespace BankServices.Realization.BalanceCalculator;

public interface IBalanceUpdaterContext
{
    public void Update(BankAccount account, Operation op);
}