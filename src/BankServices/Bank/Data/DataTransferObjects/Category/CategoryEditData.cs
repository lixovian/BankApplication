namespace BankServices.Bank.Data.DataTransferObjects.Category;

public class CategoryEditData : IDataTransferObject
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public CategoryEditData(Objects.Category data)
    {
        Id = data.Id;
        Name = data.Name;
    }

    public CategoryEditData(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}