using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Operation;

namespace BankApplication.Service.Formatter;

public interface IBankAccountFormatter
{
    public string Format(BankAccountData data, IList<OperationData> operations);
}