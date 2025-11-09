using BankApplication.Gui;
using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Category;

public class CategoryEditView : TimeDebugView
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private LabelUnit _dataLabel = null!;
    private InputUnit _name = null!;
    
    private CategoryData _editing = null!;
    
    private bool _triggerUpdate;

    private void ParseArgs(object[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("Не передана категория для редактирования");
        }

        try
        { 
            _editing = (CategoryData) args[0];
        }
        catch (InvalidCastException e)
        {
            throw new ArgumentException("Переданы неверные данные для редактирования");
        }
    }
    
    private void SetInfo()
    {
        var formatter = Services.Get<FormatterFacade>();
        _infoLabel.SetLabel(formatter.FormatCategory(_editing));
    }

    private void Edit()
    {
        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<IEditCommand<CategoryEditData>>();
        var facade = Services.Get<CategoryFacade>();

        try
        { 
            handler.Handle(command, new CategoryEditData(_editing.Id, _name.GetData()));
            _dataLabel.SetLabel("--Изменение произошло успешно--");
        }
        catch (ArgumentException e)
        {
            _dataLabel.SetLabel($"--{e.Message}--"); 
        }

        _editing = facade.GetCategory(_editing.Id);
        
        SetInfo();
        _triggerUpdate = true;
    }
    
    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        var manager = Services.Get<IViewManager>();

        ParseArgs(args);

        _infoLabel = new LabelUnit("label", "");
        _dataLabel = new LabelUnit("data", "--Ожидание изменения--");
        _name = new InputUnit("label", "Имя");
        
        _name.SetData(_editing.Name);
        SetInfo();
        
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("accounts")), 
                new ButtonUnit("edit", "Изменить категорию", Edit), 
            }, true),
            new LabelUnit("title", "Изменить категорию:"),
            (_name),
            new LabelUnit("title2", "Текущие данные:"),
            _infoLabel,
            _dataLabel,
            _debug,
        ];
        _block = new UnitBlock("block", units);
        
        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        base.OnIteration(key);
        
        _dataLabel.SetLabel("--Ожидание изменения--");
        _block.Update(key);
        
        if (_triggerUpdate)
        {
            Console.Clear();
            _block.Update();
            
            _triggerUpdate = false;
        }
    }
}