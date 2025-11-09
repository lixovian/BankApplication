using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.BankAccount;

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