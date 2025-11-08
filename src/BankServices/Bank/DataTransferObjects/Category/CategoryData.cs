using System.Text.Json.Serialization;
using BankServices.Objects.Service;

namespace BankServices.Bank.DataTransferObjects.Category;

public class CategoryData : IDataTransferObject
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public TransactionType Type { get; private set; }
    

    public CategoryData(Objects.Category data)
    {
        Id = data.Id;
        Name = data.Name;
        Type = data.Type;
    }

    [JsonConstructor]
    public CategoryData(Guid id, string name, TransactionType type)
    {
        Id = id;
        Name = name;
        Type = type;
    }
}