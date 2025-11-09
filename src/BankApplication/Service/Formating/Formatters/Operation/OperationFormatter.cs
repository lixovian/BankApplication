using System.Text;
using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankApplication.Service.Formating.Formatters.Operation;

public class OperationFormatter : IOperationFormatter
{
    public string Format(OperationData data, CategoryData? category, BankAccountData account)
    {
        StringBuilder output = new StringBuilder();

        output.AppendLine($"ID: {data.Id}");
        output.AppendLine($"Описание: {data.Description}");
        output.AppendLine($"Сумма: {data.Amount}");
        output.AppendLine($"Дата: {data.Date:dd.MM.yyyy HH:mm:ss zz}");
        output.AppendLine($"Тип транзакции: {(data.Type == TransactionType.Income ? "Доход" : "Расход")}");

        output.AppendLine($"Аккаунт: {account.Name}");
        output.AppendLine($"Категория: {(category == null ? "Нет" : category.Name)}");

        return output.ToString();
    }

    public string FormatInline(OperationData data)
    {
        return $"{(data.Type == TransactionType.Income ? '+' : '-')}{data.Amount} ({data.Id})";
    }
    
    public string FormatList(IList<OperationData> operations)
    {
        StringBuilder output = new StringBuilder();
        
        if (operations.Count == 0)
        { 
            output.AppendLine($"--Нет операций--");
        }
        else
        {
            foreach (var op in operations)
            {
                output.AppendLine(FormatInline(op));
            }
        }
        
        return output.ToString();
    }
}