using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Patterns.Facades;

namespace BankServices.Connection.Commands.BankAccount;

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