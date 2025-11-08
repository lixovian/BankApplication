namespace BankServices.Bank.Validators.Base.Category;

public class CategoryChecker : ICategoryChecker
{
    public bool Check(Objects.Category item, out string message)
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