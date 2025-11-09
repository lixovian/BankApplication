using BankApplication.Gui;
using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Operation;

public class OperationEditView : TimeDebugView
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private LabelUnit _dataLabel = null!;
    private InputUnit _descriptionInput = null!;
    private CategoryChooser _categoryChooser = null!;
    

    private OperationData _editing = null!;
    
    private bool _triggerUpdate;
    
    private IList<CategoryData?> _categories = null!;
    
    private void SetData()
    {
        var facade = Services.Get<CategoryFacade>();
        _categories = facade.GetCategories()!;
        _categories.Insert(0, null);
        
        _categoryChooser.SetData(_categories);
    }

    private void ParseArgs(object[] args)
    {
        if (args.Length < 1)
            throw new ArgumentException("Не передана операция для редактирования");

        try
        { 
            _editing = (OperationData) args[0];
        }
        catch (InvalidCastException)
        {
            throw new ArgumentException("Переданы неверные данные для редактирования");
        }
    }
    
    private void SetInfo()
    {
        var formatter = Services.Get<FormatterFacade>();
        _infoLabel.SetLabel(formatter.FormatOperation(_editing));
    }

    private void Edit()
    {
        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<IEditCommand<OperationEditData>>();
        var facade = Services.Get<OperationFacade>();

        try
        { 
            var newDescription = _descriptionInput.GetData();
            var newCategoryId = _categoryChooser.GetRealValue();

            handler.Handle(command, new OperationEditData(_editing.Id, newDescription, newCategoryId));
            _dataLabel.SetLabel("--Изменение произошло успешно--");
        }
        catch (ArgumentException e)
        {
            _dataLabel.SetLabel($"--{e.Message}--"); 
        }

        _editing = facade.GetOperation(_editing.Id);
        
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
        _descriptionInput = new InputUnit("desc", "Описание");
        _categoryChooser = new CategoryChooser("category");
        
        SetInfo();
        SetData();
        
        _descriptionInput.SetData(_editing.Description);
        _categoryChooser.SetActiveValue(_editing.CategoryId);
        
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("operations")), 
                new ButtonUnit("edit", "Изменить операцию", Edit), 
            }, true),
            new LabelUnit("title", "Изменить операцию:"),
            _descriptionInput,
            _categoryChooser,
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
