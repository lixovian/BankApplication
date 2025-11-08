using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.Operation;

namespace BankServices.Patterns.Fabrics.Operation;

public class OperationFabric : IObjectFabric<Objects.Operation, OperationRequiredData>
{
    private readonly IOperationChecker _checker;

    public OperationFabric(IOperationChecker checker)
    {
        _checker = checker;
    }

    public Objects.Operation Create(OperationRequiredData data)
    {
        var obj = new Objects.Operation(Guid.NewGuid(), data.Type, data.BankAccountId, data.Amount, DateTime.Now, data.Description, data.CategoryId);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}