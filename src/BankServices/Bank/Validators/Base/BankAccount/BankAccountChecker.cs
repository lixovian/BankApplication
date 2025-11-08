namespace BankServices.Bank.Validators.Base.BankAccount;

public class BankAccountChecker : IBankAccountChecker
{
    public bool Check(Objects.BankAccount item, out string message)
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