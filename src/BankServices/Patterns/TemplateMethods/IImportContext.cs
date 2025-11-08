using BankServices.Patterns.Facades;

namespace BankServices.Patterns.TemplateMethods;

public interface IImportContext
{
    public void Import(string path, BankAccountFacade accountsFacade, CategoryFacade categoriesFacade,
        OperationFacade operationsFacade);
}