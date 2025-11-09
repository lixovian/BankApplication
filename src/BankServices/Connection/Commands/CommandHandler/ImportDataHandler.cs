using BankServices.Data.DataTransferObjects;
using BankServices.Realization.DomainFacades;
using BankServices.Realization.Import;

namespace BankServices.Connection.Commands.CommandHandler;

public class ImportDataHandler : IDataHandler<ImportData>
{
    private readonly IImportContext _importService;

    private readonly BankAccountFacade _accountFacade;
    private readonly CategoryFacade _categoryFacade;
    private readonly OperationFacade _operationFacade;

    public ImportDataHandler(IImportContext exportService, BankAccountFacade accountFacade, CategoryFacade categoryFacade, OperationFacade operationFacade)
    {
        _importService = exportService;
        _accountFacade = accountFacade;
        _categoryFacade = categoryFacade;
        _operationFacade = operationFacade;
    }

    public void Handle(ImportData input)
    {
        _importService.Import(input.Path, _accountFacade, _categoryFacade, _operationFacade);
    }
}