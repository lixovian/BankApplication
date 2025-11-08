using BankServices.Bank.DataTransferObjects;

namespace BankApplication.Service.Formatter;

public interface IDateRangeFormatter
{
    public string Format(DateRangeData data, decimal range);
}