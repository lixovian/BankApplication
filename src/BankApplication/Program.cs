using BankApplication.Service;
using BankApplication.Views;
using BankApplication.Views.Analytics;
using BankApplication.Views.BankAccount;
using BankApplication.Views.Category;
using BankApplication.Views.Data;
using BankApplication.Views.Operation;
using ViewManagerLibrary.ViewManager;

namespace BankApplication;

internal static class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public static void Main()
    {
        IViewManager manager = Services.Get<IViewManager>();
        
        // Добавляем окна интерфейса
        manager.AddView("menu", new MenuView());
        
        manager.AddView("accounts", new BankAccountView());
        manager.AddView("add_account", new BankAccountCreateView());
        manager.AddView("edit_account", new BankAccountEditView());
        
        manager.AddView("categories", new CategoryView());
        manager.AddView("add_category", new CategoryCreateView());
        manager.AddView("edit_category", new CategoryEditView());
        
        manager.AddView("operations", new OperationView());
        manager.AddView("add_operation", new OperationCreateView());
        manager.AddView("edit_operation", new OperationEditView());
        
        manager.AddView("date_analytic", new DateAnalyticsView());
        manager.AddView("category_analytic", new CategoryAnalyticsView());
        
        manager.AddView("import", new ImportView());
        manager.AddView("export", new ExportView());
        
        manager.ChangeView("menu");
        manager.StartManager();
    }
}