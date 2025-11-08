using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.Base.Operation;

namespace BankServices.Patterns.Fabrics.Operation;

public class OperationRetrieveFabric : IObjectFabric<Objects.Operation, OperationData>
{
    private readonly IOperationChecker _checker;

    public OperationRetrieveFabric(IOperationChecker checker)
    {
        _checker = checker;
    }

    public Objects.Operation Create(OperationData data)
    {
        var obj = new Objects.Operation(data.Id, data.Type, data.BankAccountId, data.Amount, data.Date, data.Description, data.CategoryId);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}