using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Realization.Validators.DataValidators.BankAccount;

namespace BankServices.Bank.Realization.DomainFabrics.BankAccount;

public class BankAccountFabric : IObjectFabric<Data.Objects.BankAccount, BankAccountRequiredData>
{
    private readonly IBankAccountChecker _checker;

    public BankAccountFabric(IBankAccountChecker checker)
    {
        _checker = checker;
         
    }

    public Data.Objects.BankAccount Create(BankAccountRequiredData data)
    {
        var obj = new Data.Objects.BankAccount(Guid.NewGuid(), data.Name, 0);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}