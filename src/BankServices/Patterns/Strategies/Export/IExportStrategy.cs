using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Objects.Service;

namespace BankServices.Patterns.Strategies.Export;

public interface IExportStrategy
{
    public FileType Type { get; }

    public void Export(string path, IList<BankAccountData> accounts, IList<CategoryData> categories, IList<OperationData> operations);
}