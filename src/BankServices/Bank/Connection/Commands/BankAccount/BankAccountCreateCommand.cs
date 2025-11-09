using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Connection.Commands.BankAccount;

public class BankAccountCreateCommand : ICreateCommand<BankAccountRequiredData>
{
    readonly BankAccountFacade _facade;
    public BankAccountCreateCommand(BankAccountFacade facade)
    {
        _facade = facade;
    }

    public void Execute(BankAccountRequiredData requiredData)
    {
        _facade.CreateBankAccount(requiredData);
    }
}