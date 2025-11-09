using BankServices.Bank.Data.DataTransferObjects;

namespace BankApplication.Service.Formating.Formatters.DateRange;

public class DateRangeFormatter : IDateRangeFormatter
{
    public string Format(DateRangeData data, decimal range)
    {
        return
            $"От {data.From.ToShortDateString() + ' ' + data.From.ToShortTimeString()} до {data.To.ToShortDateString() + ' ' + data.To.ToShortTimeString()} - денег {(range < 0 ? "потрачено" : "накоплено")} {range}";
    }
}