using BankApplication.Service.Formating;
using BankApplication.Service.Formating.Formatters.BankAccount;
using BankApplication.Service.Formating.Formatters.Category;
using BankApplication.Service.Formating.Formatters.DateRange;
using BankApplication.Service.Formating.Formatters.Operation;
using BankServices.Bank.Connection.CommandDecorators;
using BankServices.Bank.Connection.CommandMediators;
using BankServices.Bank.Connection.Commands;
using BankServices.Bank.Connection.Commands.BankAccount;
using BankServices.Bank.Connection.Commands.Category;
using BankServices.Bank.Connection.Commands.CommandHandler;
using BankServices.Bank.Connection.Commands.Operation;
using BankServices.Bank.Data.Containers.BankAccount;
using BankServices.Bank.Data.Containers.Category;
using BankServices.Bank.Data.Containers.Operation;
using BankServices.Bank.Data.DataTransferObjects;
using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Data.Objects;
using BankServices.Bank.Realization.Analytics;
using BankServices.Bank.Realization.Analytics.Services.CategoryGroup;
using BankServices.Bank.Realization.Analytics.Services.MoneyAmplitude;
using BankServices.Bank.Realization.BalanceCalculator;
using BankServices.Bank.Realization.DomainDecorators;
using BankServices.Bank.Realization.DomainFabrics;
using BankServices.Bank.Realization.DomainFabrics.BankAccount;
using BankServices.Bank.Realization.DomainFabrics.Category;
using BankServices.Bank.Realization.DomainFabrics.Operation;
using BankServices.Bank.Realization.DomainFacades;
using BankServices.Bank.Realization.Export;
using BankServices.Bank.Realization.Export.Realizations;
using BankServices.Bank.Realization.Import;
using BankServices.Bank.Realization.Import.Realizations;
using BankServices.Bank.Realization.Observers.CategoryObserver;
using BankServices.Bank.Realization.Observers.CategoryObserver.Subscribers;
using BankServices.Bank.Realization.Validators.ContainerValidators.BankAccount;
using BankServices.Bank.Realization.Validators.ContainerValidators.Operation;
using BankServices.Bank.Realization.Validators.DataValidators.BankAccount;
using BankServices.Bank.Realization.Validators.DataValidators.Category;
using BankServices.Bank.Realization.Validators.DataValidators.Operation;
using Microsoft.Extensions.DependencyInjection;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Service;


public static class Services
{
    private static readonly IServiceProvider Provider;

    
    static Services()
    {
        IServiceCollection collection = new ServiceCollection();
        
        collection.AddSingleton<IViewManager, ViewManager>();
        
        collection.AddTransient<IOperationContainerRemoveChecker, OperationContainerRemoveChecker>();
        collection.AddTransient<IOperationContainerAddChecker, OperationContainerAddChecker>();
        
        collection.AddSingleton<ICategoryUpdateObserver, CategoryUpdateObserver>();
        collection.AddSingleton<ICategoryUpdateSubscriber, OperationContainerUpdater>();
        
        collection.AddSingleton<IBalanceCalculationStrategy, BalanceCalculationStrategy>();
        collection.AddSingleton<IBalanceUpdaterContext, BalanceUpdaterContext>();
        
        collection.AddSingleton<IBankAccountValidatorHandler, BankAccountValidatorHandler>();
        collection.AddSingleton<IBankAccountRemoveChecker, BankAccountRemoveChecker>();
        
        // Export
        collection.AddSingleton<IDataHandler<ExportData>, ExportDataHandler>();
        collection.AddSingleton<IExportContext, ExportContext>();
        
        collection.AddSingleton<IExportStrategy, CsvExportStrategy>();
        collection.AddSingleton<IExportStrategy, YamlExportStrategy>();
        collection.AddSingleton<IExportStrategy, JsonExportStrategy>();
        
        // Import
        collection.AddSingleton<IObjectFabric<BankAccount, BankAccountData>, BankAccountRetrieveFabric>();
        collection.AddSingleton<IObjectFabric<Category, CategoryData>, CategoryRetrieveFabric>();
        collection.AddSingleton<IObjectFabric<Operation, OperationData>, OperationRetrieveFabric>();
        
        collection.AddSingleton<IImportContext, ImportContext>();
        collection.AddSingleton<DataImporter, CsvImporter>();
        collection.AddSingleton<DataImporter, JsonImporter>();
        collection.AddSingleton<DataImporter, YamlImporter>();
        
        collection.AddSingleton<IDataHandler<ImportData>, ImportDataHandler>();
        
        // Analytics
        collection.AddSingleton<ICategoryGroupHandler, CategoryGroupHandler>();
        collection.AddTransient<INullCategoryGroupStrategy, NullCategoryGroupStrategy>();
        collection.AddTransient<IValueCategoryGroupStrategy, ValueCategoryGroupStrategy>();
        
        collection.AddTransient<IMoneyAmplitudeAnalyticStrategy, MoneyAmplitudeAnalyticStrategy>();
        collection.AddTransient<IMoneyAmplitudeHandler, MoneyAmplitudeHandler>();
        
        collection.AddTransient<IDateRangeFormatter, DateRangeFormatter>();
        
        collection.AddSingleton<AnalyticsFacade>();
        
        // BankAccount
        collection.AddTransient<ICreateCommand<BankAccountRequiredData>, BankAccountCreateCommand>();
        collection.AddTransient<IDeleteCommand<BankAccountIdentifierData>, BankAccountDeleteCommand>();
        collection.AddTransient<IEditCommand<BankAccountEditData>, BankAccountEditCommand>();
        
        collection.AddTransient<IBankAccountChecker, BankAccountChecker>();
        collection.AddSingleton<IObjectFabric<BankAccount, BankAccountRequiredData>, BankAccountFabric>();
        collection.AddSingleton<IObjectFabric<BankAccount, BankAccountDuplicateData>, BankAccountDuplicateFabric>();

        collection.AddSingleton<IBankAccountContainer, BankAccountContainer>();
        collection.AddSingleton<BankAccountFacade>();
        
        collection.AddSingleton<IBankAccountFormatter, BankAccountFormatter>();
        
        // Category
        collection.AddTransient<ICreateCommand<CategoryRequiredData>, CategoryCreateCommand>();
        collection.AddTransient<IDeleteCommand<CategoryIdentifierData>, CategoryDeleteCommand>();
        collection.AddTransient<IEditCommand<CategoryEditData>, CategoryEditCommand>();
        
        collection.AddTransient<ICategoryChecker, CategoryChecker>();
        collection.AddSingleton<IObjectFabric<Category, CategoryRequiredData>, CategoryFabric>();
        collection.AddSingleton<IObjectFabric<Category, CategoryDuplicateData>, CategoryDuplicateFabric>();
        
        collection.AddSingleton<ICategoryContainer, CategoryContainer>();
        collection.AddSingleton<CategoryFacade>();
        
        collection.AddSingleton<ICategoryFormatter, CategoryFormatter>();
        
        // Operation
        collection.AddTransient<ICreateCommand<OperationRequiredData>, OperationCreateCommand>();
        collection.AddTransient<IDeleteCommand<OperationIdentifierData>, OperationDeleteCommand>();
        collection.AddTransient<IEditCommand<OperationEditData>, OperationEditCommand>();
        
        collection.AddTransient<IOperationChecker, OperationChecker>();
        collection.AddSingleton<IObjectFabric<Operation, OperationRequiredData>, OperationFabric>();
        collection.AddSingleton<IObjectFabric<Operation, OperationDuplicateData>, OperationDuplicateFabric>();
        
        collection.AddSingleton<IOperationContainer, OperationContainer>();
        collection.AddSingleton<OperationFacade>();
        
        collection.AddSingleton<IOperationFormatter, OperationFormatter>();

        collection.AddTransient<IOperationContainerAddChecker, OperationContainerAddChecker>();

        // Commands
        collection.AddSingleton<ICommandTimeMediator, CommandTimeMediator>();
        collection.AddTransient<ICommandHandler, CommandHandler>();
        
        collection.AddSingleton<FormatterFacade>();
        
        collection.Decorate<ICommandHandler, CommandTimeDecorator>();
        collection.Decorate<IOperationContainer, OperationContainerValidationDecorator>();

        Provider = collection.BuildServiceProvider();
    }
    
    public static T Get<T>()
    {
        T? service = Provider.GetService<T>();

        if (service == null)
        {
            throw new NullReferenceException();
        }
        
        return service;
    }
}