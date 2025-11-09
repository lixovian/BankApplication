using BankServices.Bank.Data.DataTransferObjects;

namespace BankApplication.Service.Formating.Formatters.DateRange;

public interface IDateRangeFormatter
{
    public string Format(DateRangeData data, decimal range);
}