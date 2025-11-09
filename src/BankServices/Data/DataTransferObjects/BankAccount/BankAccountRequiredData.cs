namespace BankServices.Data.DataTransferObjects.BankAccount;

public class BankAccountRequiredData : IDataTransferObject
{
    public BankAccountRequiredData(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}