using BankServices.Data.DataTransferObjects;

namespace BankServices.Realization.Analytics.Services.MoneyAmplitude;

public interface IMoneyAmplitudeHandler
{
    public decimal Handle(DateRangeData data);
}