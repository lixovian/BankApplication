using BankApplication.Gui;
using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Bank.Connection.Commands;
using BankServices.Bank.Connection.Commands.CommandHandler;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Category;

public class CategoryView : TimeDebugView
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private CategoryChooser _chooser = null!;

    private IList<CategoryData?> _categories = null!;
    
    private bool _triggerUpdate;

    private void SetData()
    {
        var facade = Services.Get<CategoryFacade>();
        _categories = facade.GetCategories()!;
        _categories.Insert(0, null);
        
        _chooser.SetData(_categories);
    }

    private void UpdateChosenCategory()
    {
        var chosen = _chooser.GetChosen(_categories);

        var formatter = Services.Get<FormatterFacade>();
        _infoLabel.SetLabel(formatter.FormatCategory(chosen));
    }

    private void Delete()
    {
        var chosen = _chooser.GetChosen(_categories);

        if (chosen == null)
        { 
            return;
        }

        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<IDeleteCommand<CategoryIdentifierData>>();

        try
        {
            handler.Handle(command, new CategoryIdentifierData(chosen.Id));
        }
        catch (ArgumentException e)
        {
            _debug.SetLabel($"--{e.Message}--");
            return;
        }
        
        SetData();
        UpdateChosenCategory();
        
        _triggerUpdate = true;
    }

    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        var manager = Services.Get<IViewManager>();

        _infoLabel = new LabelUnit("label", "");
        _chooser = new CategoryChooser("chooser");
        
        SetData();
        
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
                new ButtonUnit("create", "Новая категория", () => manager.ChangeView("add_category")),
                new ButtonUnit("delete", "Удалить категорию", Delete),
                new ButtonUnit("edit", "Изменить категорию", () =>
                {
                    var chosen = _chooser.GetChosen(_categories);

                    if (chosen == null)
                    {
                        return;
                    }
                    
                    manager.ChangeView("edit_category", chosen);
                }),
            }, true),
            new LabelUnit("title", "Просмотр категорий:"),
            _chooser,
            new LabelUnit("title2", "Информация о выбранной категории:"),
            _infoLabel,
            _debug,
        ];
        _block = new UnitBlock("block", units);

        _chooser.OnModify = UpdateChosenCategory;
        UpdateChosenCategory();
        
        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        base.OnIteration(key);
        _block.Update(key);

        if (_triggerUpdate)
        {
            Console.Clear();
            _block.Update();

            _triggerUpdate = false;
        }
    }
}
