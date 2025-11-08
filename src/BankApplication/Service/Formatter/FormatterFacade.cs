using BankServices.Bank.DataTransferObjects;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Bank.DataTransferObjects.Category;
using BankServices.Bank.DataTransferObjects.Operation;
using BankServices.Patterns.Facades;

namespace BankApplication.Service.Formatter;

public class FormatterFacade
{
    private readonly OperationFacade _operationFacade;
    private readonly CategoryFacade _categoryFacade;
    private readonly BankAccountFacade _accountFacade;
    private readonly AnalyticsFacade _analyticsFacade;

    private readonly IBankAccountFormatter _accountFormatter;
    private readonly ICategoryFormatter _categoryFormatter;
    private readonly IOperationFormatter _operationFormatter;
    private readonly IDateRangeFormatter _dateFormatter;

    public FormatterFacade(OperationFacade opFacade, IBankAccountFormatter accountFormatter,
        ICategoryFormatter categoryFormatter, IOperationFormatter operationFormatter, CategoryFacade categoryFacade,
        BankAccountFacade accountFacade, AnalyticsFacade analyticsFacade, IDateRangeFormatter dateFormatter)
    {
        _operationFacade = opFacade;
        _accountFormatter = accountFormatter;
        _categoryFormatter = categoryFormatter;
        _operationFormatter = operationFormatter;
        _categoryFacade = categoryFacade;
        _accountFacade = accountFacade;
        _analyticsFacade = analyticsFacade;
        _dateFormatter = dateFormatter;
    }

    public string FormatAccount(BankAccountData data)
    {
        return _accountFormatter.Format(data, _operationFacade.GetAccountOperations(data));
    }

    public string FormatCategory(CategoryData? data)
    {
        return _categoryFormatter.Format(data, _operationFacade.GetCategoryOperations(data));
    }

    public string FormatOperation(OperationData data)
    {
        var category = data.CategoryId.HasValue
            ? _categoryFacade.GetCategory(data.CategoryId.Value)
            : null;
        var account = _accountFacade.GetAccount(data.BankAccountId);

        return _operationFormatter.Format(data, category, account);
    }

    public string FormatCategoryTotal(CategoryData? data)
    {
        return _categoryFormatter.FormatInline(data, _analyticsFacade.CalculateTotalAmountByCategory(data));
    }

    public string FormatAmplitudeTotal(DateRangeData data)
    {
        return _dateFormatter.Format(data, _analyticsFacade.CalculateTotalAmountByDateRange(data));
    }
}