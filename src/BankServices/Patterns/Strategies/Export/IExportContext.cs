using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Objects.Service;

namespace BankServices.Patterns.Strategies.Export;

public interface IExportContext
{
    public void Export(string path, FileType type, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations);
}