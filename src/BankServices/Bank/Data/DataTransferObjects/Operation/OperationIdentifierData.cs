namespace BankServices.Bank.Data.DataTransferObjects.Operation;

public class OperationIdentifierData : IDataTransferObject
{
    public Guid Id { get; private set; }

    public OperationIdentifierData(Guid id)
    {
        Id = id;
    }

    public OperationIdentifierData(Objects.BankAccount data)
    {
        Id = data.Id;
    }
}