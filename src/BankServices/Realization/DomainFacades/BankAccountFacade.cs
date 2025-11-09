using BankServices.Data.Containers.BankAccount;
using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.Objects;
using BankServices.Realization.BalanceCalculator;
using BankServices.Realization.DomainFabrics;
using BankServices.Realization.Validators.ContainerValidators.BankAccount;

namespace BankServices.Realization.DomainFacades;

public class BankAccountFacade
{
    private readonly IObjectFabric<BankAccount, BankAccountRequiredData> _fabric;
    private readonly IObjectFabric<BankAccount, BankAccountDuplicateData> _fabricDuplicator;
    
    private readonly IBankAccountContainer _accountsContainer;
    
    private readonly IBankAccountValidatorHandler _validatorHandler;
    
    private readonly IBalanceUpdaterContext _balanceUpdaterContext;
    
    private readonly IObjectFabric<BankAccount, BankAccountData> _retrieveFabric;

    public BankAccountFacade(IBankAccountContainer accountsContainer, IObjectFabric<BankAccount, BankAccountRequiredData> fabric, IObjectFabric<BankAccount, BankAccountDuplicateData> fabricDuplicator, IBalanceUpdaterContext balanceUpdaterContext, IBankAccountValidatorHandler validatorHandler, IObjectFabric<BankAccount, BankAccountData> accountFabric)
    {
        _accountsContainer = accountsContainer;
        
        _fabric = fabric;
        _fabricDuplicator = fabricDuplicator;
        _balanceUpdaterContext = balanceUpdaterContext;
        _validatorHandler = validatorHandler;
        _retrieveFabric = accountFabric;
    }

    public void CreateBankAccount(BankAccountRequiredData data)
    {
        _accountsContainer.Add(_fabric.Create(data));
    }
    
    public void AddBankAccount(BankAccountData data)
    {
        _accountsContainer.Add(_retrieveFabric.Create(data));
    }

    public void EditBankAccount(BankAccountEditData data)
    {
        var baseData = _accountsContainer.GetData(data.Id);
        var clone = _fabricDuplicator.Create(new BankAccountDuplicateData(baseData, data));
        _accountsContainer.Edit(clone);
    }

    public void DeleteBankAccount(BankAccountIdentifierData data)
    {
        _validatorHandler.Handle(data.Id);
        _accountsContainer.Remove(data.Id);
    }
    
    public IList<BankAccountData> GetAccounts()
    {
        return _accountsContainer.GetAllData();
    }
    
    public BankAccountData GetAccount(Guid accountId)
    {
        return _accountsContainer.GetData(accountId);
    }
    
    public void UpdateBalance(Guid accountId, Operation operation)
    {
        _balanceUpdaterContext.Update(_accountsContainer.Get(accountId), operation);
    }
}