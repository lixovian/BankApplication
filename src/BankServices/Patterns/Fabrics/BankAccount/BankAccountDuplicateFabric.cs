using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.BankAccount;

namespace BankServices.Patterns.Fabrics.BankAccount;

public class BankAccountDuplicateFabric : IObjectFabric<Objects.BankAccount, BankAccountDuplicateData>
{
    private readonly IBankAccountChecker _checker;

    public BankAccountDuplicateFabric(IBankAccountChecker checker)
    {
        _checker = checker;
    }

    public Objects.BankAccount Create(BankAccountDuplicateData data)
    {
        var obj = new Objects.BankAccount(data.Main.Id, data.NewName, data.Main.Balance);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}