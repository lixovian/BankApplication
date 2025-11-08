namespace BankServices.Bank.DataTransferObjects;

public class CommandTimeData
{
    public CommandTimeData(TimeSpan elapsed)
    {
        Elapsed = elapsed;
    }

    public TimeSpan Elapsed { get; private set; } 
}