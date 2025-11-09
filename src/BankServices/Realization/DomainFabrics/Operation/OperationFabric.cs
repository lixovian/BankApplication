using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.Validators.DataValidators.Operation;

namespace BankServices.Realization.DomainFabrics.Operation;

public class OperationFabric : IObjectFabric<Data.Objects.Operation, OperationRequiredData>
{
    private readonly IOperationChecker _checker;

    public OperationFabric(IOperationChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.Operation Create(OperationRequiredData data)
    {
        var obj = new Data.Objects.Operation(Guid.NewGuid(), data.Type, data.BankAccountId, data.Amount, DateTime.Now, data.Description, data.CategoryId);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}