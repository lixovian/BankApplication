using System.Text.Json;
using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Realization.Export.Realizations;

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