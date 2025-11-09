namespace BankServices.Realization.Validators.DataValidators.Operation;

public class OperationChecker : IOperationChecker
{
    public bool Check(Data.Objects.Operation item, out string message)
    {
        if (item.Description.Length > 50)
        {
            message = "Слишком длинное имя";
            return false;
        }

        if (item.Amount <= 0)
        {
            message = "Отрицательный перевод невозможен";
            return false;
        }
        
        message = "";
        return true;
    }
}