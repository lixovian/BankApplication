using BankApplication.Service.Formating;
using BankApplication.Service.Formating.Formatters.BankAccount;
using BankApplication.Service.Formating.Formatters.Category;
using BankApplication.Service.Formating.Formatters.DateRange;
using BankApplication.Service.Formating.Formatters.Operation;
using BankServices.Connection.CommandDecorators;
using BankServices.Connection.CommandMediators;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.BankAccount;
using BankServices.Connection.Commands.Category;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Connection.Commands.Operation;
using BankServices.Data.Containers.BankAccount;
using BankServices.Data.Containers.Category;
using BankServices.Data.Containers.Operation;
using BankServices.Data.DataTransferObjects;
using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Data.Objects;
using BankServices.Realization.Analytics;
using BankServices.Realization.Analytics.Services.CategoryGroup;
using BankServices.Realization.Analytics.Services.MoneyAmplitude;
using BankServices.Realization.BalanceCalculator;
using BankServices.Realization.DomainDecorators;
using BankServices.Realization.DomainFabrics;
using BankServices.Realization.DomainFabrics.BankAccount;
using BankServices.Realization.DomainFabrics.Category;
using BankServices.Realization.DomainFabrics.Operation;
using BankServices.Realization.DomainFacades;
using BankServices.Realization.Export;
using BankServices.Realization.Export.Realizations;
using BankServices.Realization.Import;
using BankServices.Realization.Import.Realizations;
using BankServices.Realization.Observers.CategoryObserver;
using BankServices.Realization.Observers.CategoryObserver.Subscribers;
using BankServices.Realization.Validators.ContainerValidators.BankAccount;
using BankServices.Realization.Validators.ContainerValidators.Operation;
using BankServices.Realization.Validators.DataValidators.BankAccount;
using BankServices.Realization.Validators.DataValidators.Category;
using BankServices.Realization.Validators.DataValidators.Operation;
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