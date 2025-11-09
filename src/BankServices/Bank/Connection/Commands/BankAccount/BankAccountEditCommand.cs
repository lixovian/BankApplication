using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.BankAccount;

public class BankAccountEditCommand : IEditCommand<BankAccountEditData>
{
    readonly BankAccountFacade _facade;
    public BankAccountEditCommand(BankAccountFacade facade)
    {
        _facade = facade;
    }
    
    public void Execute(BankAccountEditData data)
    {
        _facade.EditBankAccount(data);
    }
}