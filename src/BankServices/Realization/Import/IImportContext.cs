using BankServices.Realization.DomainFacades;

namespace BankServices.Realization.Import;

public interface IImportContext
{
    public void Import(string path, BankAccountFacade accountsFacade, CategoryFacade categoriesFacade,
        OperationFacade operationsFacade);
}