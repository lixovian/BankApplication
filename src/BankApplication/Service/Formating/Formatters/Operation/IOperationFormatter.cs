using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;

namespace BankApplication.Service.Formating.Formatters.Operation;

public interface IOperationFormatter
{
    public string Format(OperationData data, CategoryData? category, BankAccountData account);
    public string FormatInline(OperationData data);
    public string FormatList(IList<OperationData> operations);
}