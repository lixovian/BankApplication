using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Realization.Export;

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