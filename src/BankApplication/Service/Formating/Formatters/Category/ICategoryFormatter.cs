using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;

namespace BankApplication.Service.Formating.Formatters.Category;

public interface ICategoryFormatter
{
    public string Format(CategoryData? data, IList<OperationData> operations);
    public string FormatInline(CategoryData? data, decimal amount);
}