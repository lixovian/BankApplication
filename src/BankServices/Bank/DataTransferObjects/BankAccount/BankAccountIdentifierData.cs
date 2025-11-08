namespace BankServices.Bank.DataTransferObjects.BankAccount;

public class BankAccountIdentifierData : IDataTransferObject
{
    public Guid Id { get; private set; }

    public BankAccountIdentifierData(Guid id)
    {
        Id = id;
    }

    public BankAccountIdentifierData(Objects.BankAccount data)
    {
        Id = data.Id;
    }
}