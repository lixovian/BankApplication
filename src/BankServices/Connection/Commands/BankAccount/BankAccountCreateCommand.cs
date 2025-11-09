using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Realization.DomainFacades;

namespace BankServices.Connection.Commands.BankAccount;

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