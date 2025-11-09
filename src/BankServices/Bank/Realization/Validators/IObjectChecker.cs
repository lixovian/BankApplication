namespace BankServices.Bank.Realization.Validators;

public interface IObjectChecker<T>
{
    public bool Check(T item, out string message);
}