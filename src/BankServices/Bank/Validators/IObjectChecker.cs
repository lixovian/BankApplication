namespace BankServices.Bank.Validators;

public interface IObjectChecker<T>
{
    public bool Check(T item, out string message);
}