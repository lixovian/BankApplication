using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Objects.Service;

namespace BankServices.Patterns.Strategies.Export;

public class ExportContext : IExportContext
{
    private readonly IEnumerable<IExportStrategy> _strategies;

    public ExportContext(IEnumerable<IExportStrategy> strategies)
    {
        _strategies = strategies;
    }

    public void Export(string path, FileType type, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations)
    { 
        var strategy = _strategies.FirstOrDefault(s => s.Type == type);

        strategy?.Export(path, accounts, categories, operations);
    }
}