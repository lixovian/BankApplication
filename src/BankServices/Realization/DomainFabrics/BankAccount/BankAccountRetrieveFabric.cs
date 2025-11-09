using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Realization.Validators.DataValidators.BankAccount;

namespace BankServices.Realization.DomainFabrics.BankAccount;

public class BankAccountRetrieveFabric : IObjectFabric<Data.Objects.BankAccount, BankAccountData>
{
    private readonly IBankAccountChecker _checker;

    public BankAccountRetrieveFabric(IBankAccountChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.BankAccount Create(BankAccountData data)
    {
        var obj = new Data.Objects.BankAccount(data.Id, data.Name, data.Balance);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}