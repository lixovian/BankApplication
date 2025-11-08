using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.Operation;

namespace BankServices.Patterns.Fabrics.Operation;

public class OperationDuplicateFabric : IObjectFabric<Objects.Operation, OperationDuplicateData>
{
    private readonly IOperationChecker _checker;

    public OperationDuplicateFabric(IOperationChecker checker)
    {
        _checker = checker;
    }

    public Objects.Operation Create(OperationDuplicateData data)
    {
        var obj = new Objects.Operation(data.Main.Id, data.Main.Type, data.Main.BankAccountId, data.Main.Amount, data.Main.Date, data.NewDescription, data.NewCategoryId);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}