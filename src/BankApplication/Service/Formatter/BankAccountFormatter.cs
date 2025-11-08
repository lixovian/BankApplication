using System.Text;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Operation;

namespace BankApplication.Service.Formatter;

public class BankAccountFormatter : IBankAccountFormatter
{
    private readonly IOperationFormatter _formatter;
    
    public BankAccountFormatter(IOperationFormatter formatter)
    {
        _formatter = formatter;
    }

    public string Format(BankAccountData data, IList<OperationData> operations)
    {
        StringBuilder output = new StringBuilder();

        output.AppendLine($"ID: {data.Id.ToString()}");
        output.AppendLine($"Имя: {data.Name}");
        output.AppendLine($"Баланс: {data.Balance}");
        
        output.AppendLine($"Операции:");
        output.Append(_formatter.FormatList(operations));

        return output.ToString();
    }
}