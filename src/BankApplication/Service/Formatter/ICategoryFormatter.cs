using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;

namespace BankApplication.Service.Formatter;

public interface ICategoryFormatter
{
    public string Format(CategoryData? data, IList<OperationData> operations);
    public string FormatInline(CategoryData? data, decimal amount);
}