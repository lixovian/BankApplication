using BankServices.Data.DataTransferObjects;
using BankServices.Realization.DomainFacades;
using BankServices.Realization.Export;

namespace BankServices.Connection.Commands.CommandHandler;

public class ExportDataHandler : IDataHandler<ExportData>
{
    private readonly IExportContext _exportService;

    private readonly BankAccountFacade _accountFacade;
    private readonly CategoryFacade _categoryFacade;
    private readonly OperationFacade _operationFacade;

    public ExportDataHandler(IExportContext exportService, BankAccountFacade accountFacade, CategoryFacade categoryFacade, OperationFacade operationFacade)
    {
        _exportService = exportService;
        
        _accountFacade = accountFacade;
        _categoryFacade = categoryFacade;
        _operationFacade = operationFacade;
    }

    public void Handle(ExportData input)
    {
        _exportService.Export(input.Path, input.Type, _accountFacade.GetAccounts(), _categoryFacade.GetCategories(), _operationFacade.GetOperations());
    }
}