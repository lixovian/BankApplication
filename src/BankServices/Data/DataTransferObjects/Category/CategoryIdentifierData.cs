namespace BankServices.Data.DataTransferObjects.Category;

public class CategoryIdentifierData : IDataTransferObject
{
    public Guid Id { get; private set; }

    public CategoryIdentifierData(Guid id)
    {
        Id = id;
    }

    public CategoryIdentifierData(Objects.BankAccount data)
    {
        Id = data.Id;
    }
}