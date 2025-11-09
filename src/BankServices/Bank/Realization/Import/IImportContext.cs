using BankServices.Bank.Realization.DomainFacades;

namespace BankServices.Bank.Realization.Import;

public interface IImportContext
{
    public void Import(string path, BankAccountFacade accountsFacade, CategoryFacade categoriesFacade,
        OperationFacade operationsFacade);
}