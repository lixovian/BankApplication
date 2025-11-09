namespace BankServices.Data.DataTransferObjects.Operation;

public class OperationEditData : IDataTransferObject
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public Guid? CategoryId { get; private set; }
    
    public OperationEditData(Objects.Operation data)
    {
        Id = data.Id;
        Description = data.Description;
        CategoryId = data.CategoryId;
    }

    public OperationEditData(Guid id, string description, Guid? categoryId)
    {
        Id = id;
        Description = description;
        CategoryId = categoryId;
    }
}