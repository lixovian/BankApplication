using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;

namespace BankApplication.Service.Formating.Formatters.Operation;

public interface IOperationFormatter
{
    public string Format(OperationData data, CategoryData? category, BankAccountData account);
    public string FormatInline(OperationData data);
    public string FormatList(IList<OperationData> operations);
}