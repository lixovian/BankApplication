using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Data.Objects.Service;

namespace BankServices.Realization.Export;

public interface IExportStrategy
{
    public FileType Type { get; }

    public void Export(string path, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations);
}