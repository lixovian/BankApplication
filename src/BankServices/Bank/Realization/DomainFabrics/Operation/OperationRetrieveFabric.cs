using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.Validators.DataValidators.Operation;

namespace BankServices.Bank.Realization.DomainFabrics.Operation;

public class OperationRetrieveFabric : IObjectFabric<Data.Objects.Operation, OperationData>
{
    private readonly IOperationChecker _checker;

    public OperationRetrieveFabric(IOperationChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.Operation Create(OperationData data)
    {
        var obj = new Data.Objects.Operation(data.Id, data.Type, data.BankAccountId, data.Amount, data.Date, data.Description, data.CategoryId);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}