namespace BankServices.Realization.Validators;

public interface IObjectChecker<T>
{
    public bool Check(T item, out string message);
}