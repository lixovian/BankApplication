using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Data.Objects.Service;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace BankServices.Realization.Import.Realizations;

public class YamlImporter : DataImporter
{
    protected override (IList<BankAccountData> Accounts, IList<CategoryData> Categories, IList<OperationData> Operations) ParseRaw(string data)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        try
        {
            var retrieved = deserializer.Deserialize<FullData>(data);

            var accounts = retrieved.Accounts.Select(ConvertAccountData).ToList();
            var categories = retrieved.Categories.Select(ConvertCategoryData).ToList();
            var operations = retrieved.Operations.Select(ConvertOperationData).ToList();

            return (accounts, categories, operations);
        }
        catch (Exception)
        {
            throw new FormatException("Ошибка при чтении данных");
        }
    }

    private BankAccountData ConvertAccountData(BankAccountRawData data)
    {
        var id = Guid.Parse(data.Id);
        var name = data.Name;
        var balance = data.Balance;
        return new BankAccountData(id, name, balance);
    }
    
    private CategoryData ConvertCategoryData(CategoryRawData data)
    {
        var id = Guid.Parse(data.Id);
        var name = data.Name;
        var type = Enum.Parse<TransactionType>(data.Type);
        
        return new CategoryData(id, name, type);
    }
    
    private OperationData ConvertOperationData(OperationRawData data)
    {
        var id = Guid.Parse(data.Id);
        var accountId = Guid.Parse(data.BankAccountId);
        Guid? categoryId;
        try
        {
            categoryId = Guid.Parse(data.CategoryId);
        }
        catch (FormatException)
        {
            categoryId = null;
        }
        var description = data.Description;
        var amount = data.Amount;
        var date = DateTime.Parse(data.Date);
        var type = Enum.Parse<TransactionType>(data.Type);

        return new OperationData(id, type, accountId, amount, date, description, categoryId);
    }

    public override bool CanImport(string path)
    {
        return Path.GetExtension(path).Equals(".yaml");
    }

    private class BankAccountRawData
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public decimal Balance { get; init; }
    }
    
    private class CategoryRawData
    {
        public string Id { get; init; }
        public string Type { get; init; }
        public string Name { get; init; }
    }

    private class OperationRawData
    {
        public string Id { get; init; }
        public string Type { get; init; }
        public string BankAccountId { get; init; }
        public string CategoryId { get; init; }
        public decimal Amount { get; init; }
        public string Date { get; init; }
        public string Description { get; init; }
    }

    private class FullData
    {
        public List<BankAccountRawData> Accounts { get; init; } = [];
        public List<CategoryRawData> Categories { get; init; } = [];
        public List<OperationRawData> Operations { get; init; } = [];
    }
}