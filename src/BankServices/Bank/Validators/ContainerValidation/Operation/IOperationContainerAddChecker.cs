namespace BankServices.Bank.Validators.ContainerValidation.Operation;

public interface IOperationContainerAddChecker
{
    public bool Check(Objects.Operation item, out string message);
}