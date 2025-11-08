using BankServices.Objects.Service;

namespace BankServices.Bank.DataTransferObjects;

public class ExportData : IDataTransferObject
{
    public ExportData(string path, FileType type)
    {
        Path = path;
        Type = type;
    }

    public string Path { get; private set; }
    public FileType Type { get; private set; }
}