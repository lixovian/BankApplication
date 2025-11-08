using System.Text.Json;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Objects.Service;

namespace BankServices.Patterns.Strategies.Export.Realizations;

public class JsonExportStrategy : IExportStrategy
{
    public FileType Type => FileType.Json;
    public void Export(string path, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations)
    {
            var data = new
            {
                Accounts = accounts,
                Categories = categories,
                Operations = operations
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(data, options);
            
            
            try
            {
                File.WriteAllText(path, json);
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