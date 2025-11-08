using BankApplication.Service;
using GuiLibrary.Assembled;
using ViewManagerLibrary;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views;

/// <summary>
/// Окно, в котором отображается основное меню приложения 
/// </summary>
public class MenuView : View
{
    private ListBlock _menu = null!;

    /// <summary>
    /// Метод получения элементов списка действий
    /// </summary>
    /// <returns>Словарь названий элементов меню и соответствующих им действий</returns>
    private static Dictionary<string, Action> GetActions()
    {
        IViewManager manager = Services.Get<IViewManager>();
        
        Dictionary<string, Action> output = new()
        {
            { "Банковские счета", () => { manager.ChangeView("accounts"); } },
            { "Категории", () => { manager.ChangeView("categories"); } },
            { "Операции", () => { manager.ChangeView("operations"); } },
            { "Аналитика по категориям", () => { manager.ChangeView("category_analytic"); } },
            { "Аналитика по диапазону дат", () => { manager.ChangeView("date_analytic"); } },
            { "Импорт данных", () => { manager.ChangeView("import"); } },
            { "Экспорт данных", () => { manager.ChangeView("export"); } },
            { "Выход", () => { Environment.Exit(0); } }
        };
        return output;
    }

    public override void OnStart(object[] args)
    {
        _menu = new ListBlock("menu", "Выберите пункт меню:", GetActions());
        _menu.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _menu.Update(key);
    }
}