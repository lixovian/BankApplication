using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.BankAccount;

namespace BankServices.Patterns.Fabrics.BankAccount;

public class BankAccountFabric : IObjectFabric<Objects.BankAccount, BankAccountRequiredData>
{
    private readonly IBankAccountChecker _checker;

    public BankAccountFabric(IBankAccountChecker checker)
    {
        _checker = checker;
         
    }

    public Objects.BankAccount Create(BankAccountRequiredData data)
    {
        var obj = new Objects.BankAccount(Guid.NewGuid(), data.Name, 0);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}