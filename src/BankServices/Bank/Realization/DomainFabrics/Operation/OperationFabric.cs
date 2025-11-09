using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.Validators.DataValidators.Operation;

namespace BankServices.Bank.Realization.DomainFabrics.Operation;

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