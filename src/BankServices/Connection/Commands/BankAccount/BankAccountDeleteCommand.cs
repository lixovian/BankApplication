using BankServices.Bank.DataTransferObjects;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Patterns.Facades;

namespace BankServices.Connection.Commands.BankAccount;

public class BankAccountDeleteCommand : IDeleteCommand<BankAccountIdentifierData>
{
    readonly BankAccountFacade _facade;
    public BankAccountDeleteCommand(BankAccountFacade facade)
    {
        _facade = facade;
    }
    
    public void Execute(BankAccountIdentifierData data)
    {
        _facade.DeleteBankAccount(data);
    }
}