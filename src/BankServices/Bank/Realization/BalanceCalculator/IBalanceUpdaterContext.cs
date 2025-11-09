using BankServices.Bank.Data.Objects;

namespace BankServices.Bank.Realization.BalanceCalculator;

public interface IBalanceUpdaterContext
{
    public void Update(BankAccount account, Operation op);
}