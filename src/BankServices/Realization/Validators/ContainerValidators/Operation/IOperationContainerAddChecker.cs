namespace BankServices.Realization.Validators.ContainerValidators.Operation;

public interface IOperationContainerAddChecker
{
    public bool Check(Data.Objects.Operation item, out string message);
}