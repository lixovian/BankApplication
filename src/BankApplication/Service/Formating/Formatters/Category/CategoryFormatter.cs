using System.Text;
using BankApplication.Service.Formating.Formatters.Operation;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankApplication.Service.Formating.Formatters.Category;

public class CategoryFormatter : ICategoryFormatter
{
    private readonly IOperationFormatter _formatter;

    public CategoryFormatter(IOperationFormatter formatter)
    {
        _formatter = formatter;
    }

    public string Format(CategoryData? data, IList<OperationData> operations)
    {
        StringBuilder output = new StringBuilder();

        if (data == null)
        {
            output.AppendLine("Операции, не имеющие категории:");
        }
        else
        {
            output.AppendLine($"ID: {data.Id.ToString()}");
            output.AppendLine($"Имя: {data.Name}");
            output.AppendLine($"Тип: {(data.Type == TransactionType.Income ? "Доход" : "Расход")}");

            output.AppendLine($"Операции:");
        }

        output.Append(_formatter.FormatList(operations));

        return output.ToString();
    }

    public string FormatInline(CategoryData? data, decimal amount)
    {
        if (data == null)
        {
            return $"Без категории: {(amount >= 0 ? "+" : "-")}{Math.Abs(amount)}";
        }

        return $"{data.Name}: {(data.Type == TransactionType.Income ? "+" : "-")}{amount}";
    }
}