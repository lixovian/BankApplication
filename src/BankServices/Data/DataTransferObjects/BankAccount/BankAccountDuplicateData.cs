namespace BankServices.Data.DataTransferObjects.BankAccount;

public class BankAccountDuplicateData : IDataTransferObject
{
    public BankAccountData Main { get; private set; }
    public string NewName { get; private set; }

    public BankAccountDuplicateData(BankAccountData main, BankAccountEditData data)
    {
        Main = main;
        NewName = data.Name;
    }
}