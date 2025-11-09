namespace BankServices.Realization.Validators.DataValidators.BankAccount;

public class BankAccountChecker : IBankAccountChecker
{
    public bool Check(Data.Objects.BankAccount item, out string message)
    {
        if (item.Name.Length > 30)
        {
            message = "Слишком длинное имя";
            return false;
        }

        if (item.Name.Length == 0)
        {
            message = "Имя не может быть пустым";
            return false;
        }
        
        message = "";
        return true;
    }
}