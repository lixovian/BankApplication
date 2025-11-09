using BankServices.Data.Objects.Service;

namespace BankServices.Data.DataTransferObjects.Category;

public class CategoryRequiredData : IDataTransferObject
{
    public string Name { get; private set; }
    public TransactionType Type { get; private set; }

    public CategoryRequiredData(Objects.Category data)
    {
        Type = data.Type;
        Name = data.Name;
    }

    public CategoryRequiredData(string name, TransactionType type)
    {
        Name = name;
        Type = type;
    }
}