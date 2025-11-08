using System.Text;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Objects.Service;

namespace BankServices.Patterns.Strategies.Export.Realizations;

public class CsvExportStrategy : IExportStrategy
{
    public FileType Type => FileType.Csv;

    public void Export(string path, IList<BankAccountData> accounts, IList<CategoryData> categories,
        IList<OperationData> operations)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# Accounts");
        sb.AppendLine("Id,Name,Balance");
        foreach (var acc in accounts)
            sb.AppendLine($"{acc.Id},{acc.Name},{acc.Balance}");

        sb.AppendLine();
        sb.AppendLine("# Categories");
        sb.AppendLine("Id,Name,Type");
        foreach (var cat in categories)
            sb.AppendLine($"{cat.Id},{cat.Name},{cat.Type}");

        sb.AppendLine();
        sb.AppendLine("# Operations");
        sb.AppendLine("Id,BankAccountId,CategoryId,Amount,Date,Type,Description");
        foreach (var op in operations)
            sb.AppendLine(
                $"{op.Id},{op.BankAccountId},{op.CategoryId},{op.Amount},{op.Date:yyyy-MM-dd hh:mm:ss},{op.Type},{op.Description}");
        
        try
        {
            File.WriteAllText(path, sb.ToString());
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Неправильный путь");
        }
        catch (Exception)
        {
            throw new ArgumentException("Ошибка записи данных");
        }
    }
}