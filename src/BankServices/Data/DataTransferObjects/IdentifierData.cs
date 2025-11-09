namespace BankServices.Data.DataTransferObjects;

public class IdentifierData : IDataTransferObject
{
    public Guid Id { get; private set; }

    public IdentifierData(Guid id)
    {
        Id = id;
    }

    public IdentifierData(Objects.BankAccount data)
    {
        Id = data.Id;
    }
}