using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;

namespace BankApplication.Service.Formatter;

public interface IOperationFormatter
{
    public string Format(OperationData data, CategoryData? category, BankAccountData account);
    public string FormatInline(OperationData data);
    public string FormatList(IList<OperationData> operations);
}