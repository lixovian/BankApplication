using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.BankAccount;

namespace BankServices.Patterns.Fabrics.BankAccount;

public class BankAccountRetrieveFabric : IObjectFabric<Objects.BankAccount, BankAccountData>
{
    private readonly IBankAccountChecker _checker;

    public BankAccountRetrieveFabric(IBankAccountChecker checker)
    {
        _checker = checker;
    }

    public Objects.BankAccount Create(BankAccountData data)
    {
        var obj = new Objects.BankAccount(data.Id, data.Name, data.Balance);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}