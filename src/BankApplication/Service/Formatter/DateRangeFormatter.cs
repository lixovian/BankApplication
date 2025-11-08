using BankServices.Bank.DataTransferObjects;

namespace BankApplication.Service.Formatter;

public class DateRangeFormatter : IDateRangeFormatter
{
    public string Format(DateRangeData data, decimal range)
    {
        return
            $"От {data.From.ToShortDateString() + ' ' + data.From.ToShortTimeString()} до {data.To.ToShortDateString() + ' ' + data.To.ToShortTimeString()} - денег {(range < 0 ? "потрачено" : "накоплено")} {range}";
    }
}