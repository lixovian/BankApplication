using BankServices.Data.Containers.Operation;
using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Data.Objects;
using BankServices.Realization.BalanceCalculator;
using BankServices.Realization.DomainFabrics;

namespace BankServices.Realization.DomainFacades;

public class OperationFacade
{
    private readonly IObjectFabric<Operation, OperationRequiredData> _fabric;
    private readonly IObjectFabric<Operation, OperationDuplicateData> _fabricDuplicator;
    private readonly IOperationContainer _operationsContainer;
    
    private readonly BankAccountFacade _bankAccountFacade;
    
    private readonly IObjectFabric<Operation, OperationData> _retrieveFabric;
    
    
    public OperationFacade(IOperationContainer operationsContainer,
        IObjectFabric<Operation, OperationRequiredData> fabric,
        IObjectFabric<Operation, OperationDuplicateData> fabricDuplicator, IBalanceUpdaterContext balanceUpdaterContext, BankAccountFacade bankAccountFacade, IObjectFabric<Operation, OperationData> retrieveFabric)
    {
        _operationsContainer = operationsContainer;
        _fabric = fabric;
        _fabricDuplicator = fabricDuplicator;
        _bankAccountFacade = bankAccountFacade;
        _retrieveFabric = retrieveFabric;
    }

    public void CreateOperation(OperationRequiredData data)
    {
        var operation = _fabric.Create(data);
        _operationsContainer.Add(operation);
        
        _bankAccountFacade.UpdateBalance(data.BankAccountId, operation);
    }
    
    public void AddOperation(OperationData data)
    {
        var operation = _retrieveFabric.Create(data);
        _operationsContainer.Add(operation);
        
        _bankAccountFacade.UpdateBalance(data.BankAccountId, operation);
    }

    public void EditOperation(OperationEditData data)
    {
        var baseData = _operationsContainer.GetData(data.Id);
        var clone = _fabricDuplicator.Create(new OperationDuplicateData(baseData, data));
        _operationsContainer.Edit(clone);
    }

    public void DeleteOperation(OperationIdentifierData data)
    {
        _operationsContainer.Remove(data.Id);
    }

    public IList<OperationData> GetOperations()
    {
        return _operationsContainer.GetAllData();
    }

    public OperationData GetOperation(Guid operationId)
    {
        return _operationsContainer.GetData(operationId);
    }
    
    public IList<OperationData> GetAccountOperations(BankAccountData account)
    {
        return _operationsContainer.GetAccountOperations(account.Id);
    }
    
    public IList<OperationData> GetCategoryOperations(CategoryData? category)
    {
        return _operationsContainer.GetCategoryOperations(category?.Id);
    }
}