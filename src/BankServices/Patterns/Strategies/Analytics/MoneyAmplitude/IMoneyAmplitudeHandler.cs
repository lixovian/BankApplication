using BankServices.Bank.DataTransferObjects;

namespace BankServices.Patterns.Strategies.Analytics.MoneyAmplitude;

public interface IMoneyAmplitudeHandler
{
    public decimal Handle(DateRangeData data);
}