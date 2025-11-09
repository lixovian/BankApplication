using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Data.Objects.Service;

namespace BankServices.Realization.Export.Realizations;

public class YamlExportStrategy : IExportStrategy
{
    public FileType Type => FileType.Yaml;
    public void Export(string path, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations)
    {
        try
        {
            using var writer = new StreamWriter(path);

            writer.WriteLine("Accounts:");
            foreach (var a in accounts)
            {
                writer.WriteLine($"  - Id: \"{a.Id}\"");
                writer.WriteLine($"    Name: \"{a.Name}\"");
                writer.WriteLine($"    Balance: {a.Balance}");
            }

            writer.WriteLine();

            writer.WriteLine("Categories:");
            foreach (var c in categories)
            {
                writer.WriteLine($"  - Id: \"{c.Id}\"");
                writer.WriteLine($"    Name: \"{c.Name}\"");
                writer.WriteLine($"    Type: \"{c.Type}\"");
            }

            writer.WriteLine();

            writer.WriteLine("Operations:");
            foreach (var o in operations)
            {
                writer.WriteLine($"  - Id: \"{o.Id}\"");
                writer.WriteLine($"    Type: \"{o.Type}\"");
                writer.WriteLine($"    BankAccountId: \"{o.BankAccountId}\"");
                writer.WriteLine($"    Amount: {o.Amount}");
                writer.WriteLine($"    Date: {o.Date:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine($"    Description: \"{o.Description}\"");
                writer.WriteLine($"    CategoryId: \"{o.CategoryId}\"");
            }
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