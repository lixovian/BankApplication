namespace BankServices.Data.DataTransferObjects;

public class DateRangeData : IDataTransferObject
{
    public DateTime From { get; private set; }
    public DateTime To { get; private set; }

    public DateRangeData(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }
}