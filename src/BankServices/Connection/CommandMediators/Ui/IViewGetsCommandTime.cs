using BankServices.Data.DataTransferObjects;

namespace BankServices.Connection.CommandMediators.Ui;

public interface IViewGetsCommandTime
{
    public void GetTime(CommandTimeData data);
}