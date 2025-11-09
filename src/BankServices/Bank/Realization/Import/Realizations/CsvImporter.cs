using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Realization.Import.Realizations;

public class CsvImporter : DataImporter
{
    protected override (IList<BankAccountData> Accounts, IList<CategoryData> Categories, IList<OperationData> Operations
        ) ParseRaw(string data)
    {
        var accounts = new List<BankAccountData>();
        var categories = new List<CategoryData>();
        var operations = new List<OperationData>();

        var lines = data.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var section = "";
        
        foreach (var line in lines)
        {
            if (line.StartsWith('#'))
            {
                section = line.Trim().TrimStart('#').Trim().ToLowerInvariant();

            continue;
            }

            var parts = line.Split(',');

            if (parts[0] == "Id")
            {
                continue;
            }
            
            try
            {
                switch (section)
                {
                    case "accounts":
                        if (parts.Length < 3) throw new FormatException();

                        var id = Guid.Parse(parts[0].Trim());
                        var name = parts[1].Trim();
                        var balance = decimal.Parse(parts[2].Trim());
                        accounts.Add(new BankAccountData(id, name, balance));
                        break;

                    case "categories":
                        if (parts.Length < 3) throw new FormatException();

                        id = Guid.Parse(parts[0].Trim());
                        name = parts[1].Trim();
                        var type = Enum.Parse<TransactionType>(parts[2].Trim());

                        categories.Add(new CategoryData(id, name, type));
                        break;

                    case "operations":
                        if (parts.Length < 7) throw new FormatException();

                        id = Guid.Parse(parts[0].Trim());
                        var accountId = Guid.Parse(parts[1].Trim());
                        Guid? categoryId;
                        
                        try
                        {
                            categoryId = Guid.Parse(parts[2].Trim());
                        }
                        catch (FormatException)
                        {
                            categoryId = null;
                        }

                        var amount = decimal.Parse(parts[3].Trim());
                        var date = DateTime.Parse(parts[4].Trim());
                        type = Enum.Parse<TransactionType>(parts[5].Trim());
                        var description = parts[6].Trim();

                        operations.Add(new OperationData(id, type, accountId, amount, date, description,
                            categoryId));
                        break;

                    default:
                        throw new FormatException();
                }
            }
            catch (FormatException  e)
            {
                throw new FormatException("Неверные данные в файле");
            }
        }
        
        return (accounts, categories, operations);
    }

    public override bool CanImport(string path)
    {
        return Path.GetExtension(path).Equals(".csv");
    }
}