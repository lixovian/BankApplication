using BankServices.Bank.Containers.Operation;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Bank.Validators;
using BankServices.Bank.Validators.ContainerValidation.Operation;
using BankServices.Objects;

namespace BankServices.Patterns.Decorators;

public class OperationContainerValidationDecorator : IOperationContainer
{
    private readonly IOperationContainer _container;
    private readonly IOperationContainerAddChecker _containerAddChecker;
    private readonly IOperationContainerRemoveChecker _containerRemoveChecker;

    public OperationContainerValidationDecorator(IOperationContainer container, IOperationContainerAddChecker containerAddChecker, IOperationContainerRemoveChecker containerRemoveChecker)
    {
        _container = container;
        _containerAddChecker = containerAddChecker;
        _containerRemoveChecker = containerRemoveChecker;
    }


    public IList<OperationData> GetAccountOperations(Guid id)
    {
        return _container.GetAccountOperations(id);
    }

    public IList<OperationData> GetCategoryOperations(Guid? id)
    {
        return _container.GetCategoryOperations(id);
    }

    public void Add(Operation obj)
    {
        if (!_containerAddChecker.Check(obj, out var message))
        {
            throw new ArgumentException(message);
        }
        _container.Add(obj);
    }

    public void Remove(Guid id)
    {
        if (!_containerRemoveChecker.Check(id, _container, out var message))
        {
            throw new ArgumentException(message);
        }
        
        _container.Remove(id);
    }

    public IReadOnlyList<Operation> GetAll()
    {
        return _container.GetAll();
    }

    public void Edit(Operation obj)
    {
        _container.Edit(obj);
    }

    public Operation Get(Guid id)
    {
        return _container.Get(id);
    }

    public OperationData GetData(Guid id)
    {
        return _container.GetData(id);
    }

    public IList<OperationData> GetAllData()
    {
        return _container.GetAllData();
    }
}