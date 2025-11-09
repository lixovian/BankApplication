namespace BankServices.Bank.Data.DataTransferObjects;

public class ImportData : IDataTransferObject
{
    public ImportData(string path)
    {
        Path = path;
    }

    public string Path { get; private set; }
}