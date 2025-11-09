using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Data.Objects.Service;

namespace BankServices.Realization.Export;

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