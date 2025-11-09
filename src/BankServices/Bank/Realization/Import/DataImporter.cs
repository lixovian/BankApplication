using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Realization.Import;

public abstract class DataImporter
{
    protected abstract (IList<BankAccountData> Accounts,
        IList<CategoryData> Categories,
        IList<OperationData> Operations) ParseRaw(string data);

    public abstract bool CanImport(string path);
    
    public void Import(string path, BankAccountFacade accountsFacade, CategoryFacade categoriesFacade,
        OperationFacade operationsFacade)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Файл не найден");
        }
        
        string raw;
        try
        {
            raw = File.ReadAllText(path);
        }
        catch (Exception)
        {
            throw new IOException($"Проблема с чтением данных");
        }
        
        var (accounts, categories, operations) = ParseRaw(raw);

        foreach (var a in accounts)
        {
            accountsFacade.AddBankAccount(a);
        }

        foreach (var c in categories)
        {
            categoriesFacade.AddCategory(c);
        }

        foreach (var o in operations)
        {
            operationsFacade.AddOperation(o);
        }
    }
}