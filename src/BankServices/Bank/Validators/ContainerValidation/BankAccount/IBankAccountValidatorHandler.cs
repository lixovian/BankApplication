namespace BankServices.Bank.Validators.ContainerValidation.BankAccount;

public interface IBankAccountValidatorHandler
{
    public void Handle(Guid id);
}