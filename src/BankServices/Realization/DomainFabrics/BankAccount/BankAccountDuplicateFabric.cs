using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Realization.Validators.DataValidators.BankAccount;

namespace BankServices.Realization.DomainFabrics.BankAccount;

public class BankAccountDuplicateFabric : IObjectFabric<Data.Objects.BankAccount, BankAccountDuplicateData>
{
    private readonly IBankAccountChecker _checker;

    public BankAccountDuplicateFabric(IBankAccountChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.BankAccount Create(BankAccountDuplicateData data)
    {
        var obj = new Data.Objects.BankAccount(data.Main.Id, data.NewName, data.Main.Balance);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}