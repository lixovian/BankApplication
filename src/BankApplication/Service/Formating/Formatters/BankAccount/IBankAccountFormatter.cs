using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Operation;

namespace BankApplication.Service.Formating.Formatters.BankAccount;

public interface IBankAccountFormatter
{
    public string Format(BankAccountData data, IList<OperationData> operations);
}