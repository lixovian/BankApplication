using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Operation;

namespace BankApplication.Service.Formating.Formatters.BankAccount;

public interface IBankAccountFormatter
{
    public string Format(BankAccountData data, IList<OperationData> operations);
}