using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects.Service;

namespace BankServices.Bank.Realization.Export;

public interface IExportContext
{
    public void Export(string path, FileType type, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations);
}