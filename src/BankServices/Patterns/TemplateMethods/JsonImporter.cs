using System.Text.Json;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;

namespace BankServices.Patterns.TemplateMethods;

public class JsonImporter : DataImporter
{
    protected override (IList<BankAccountData> Accounts, IList<CategoryData> Categories, IList<OperationData> Operations
        ) ParseRaw(string data)
    {
        var retrieved = JsonSerializer.Deserialize<FullData>(data);

        if (retrieved == null)
        {
            throw new NullReferenceException("Данные не считаны");
        }

        return (retrieved.Accounts, retrieved.Categories, retrieved.Operations);
    }

    public override bool CanImport(string path)
    {
        return Path.GetExtension(path).Equals(".json");
    }

    private class FullData
    {
        public List<BankAccountData> Accounts { get; init; } = new();
        public List<CategoryData> Categories { get; init; } = new();
        public List<OperationData> Operations { get; init; } = new();
    }
}