using BankServices.Bank.Data.DataTransferObjects;

namespace BankServices.Bank.Realization.Analytics.Services.MoneyAmplitude;

public interface IMoneyAmplitudeHandler
{
    public decimal Handle(DateRangeData data);
}