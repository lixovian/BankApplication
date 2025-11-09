using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.Validators.DataValidators.Operation;

namespace BankServices.Realization.DomainFabrics.Operation;

public class OperationDuplicateFabric : IObjectFabric<Data.Objects.Operation, OperationDuplicateData>
{
    private readonly IOperationChecker _checker;

    public OperationDuplicateFabric(IOperationChecker checker)
    {
        _checker = checker;
    }

    public Data.Objects.Operation Create(OperationDuplicateData data)
    {
        var obj = new Data.Objects.Operation(data.Main.Id, data.Main.Type, data.Main.BankAccountId, data.Main.Amount, data.Main.Date, data.NewDescription, data.NewCategoryId);
        
        if (!_checker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        
        return obj;
    }
}