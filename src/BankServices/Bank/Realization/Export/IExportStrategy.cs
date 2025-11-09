using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Realization.Export;

public interface IExportStrategy
{
    public FileType Type { get; }

    public void Export(string path, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations);
}