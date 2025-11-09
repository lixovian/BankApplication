using BankApplication.Gui;
using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Bank.Connection.Commands;
using BankServices.Bank.Connection.Commands.CommandHandler;
using BankServices.Bank.Data.DataTransferObjects.Operation;
using BankServices.Bank.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Choosers;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Operation;

public class OperationView : TimeDebugView
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private HiddenChooserUnit<Guid> _chooser = null!;
    

    private IList<OperationData> _operations = null!;
    
    private bool _triggerUpdate;

    private void SetData()
    {
        var facade = Services.Get<OperationFacade>();
        _operations = facade.GetOperations();
        
        _chooser.SetRealValues(_operations.Select(c => c.Id).ToArray());
        _chooser.SetValues(_operations.Select(c => c.Id.ToString()).ToArray());
    }

    private OperationData? GetChosen()
    {
        return _operations.FirstOrDefault(x => x.Id == _chooser.GetRealValue());
    }
    
    private void UpdateChosenOperation()
    {
        var chosen = GetChosen();

        if (chosen == null)
        { 
            _debug.SetLabel("--Операция не найдена--");
            return;
        }

        var formatter = Services.Get<FormatterFacade>();
        _infoLabel.SetLabel(formatter.FormatOperation(chosen));
    }

    private void Delete()
    {
        var chosen = GetChosen();

        if (chosen == null)
        { 
            _debug.SetLabel("--Нельзя удалить несуществующую операцию--");
            return;
        }

        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<IDeleteCommand<OperationIdentifierData>>();

        try
        {
            handler.Handle(command, new OperationIdentifierData(chosen.Id));
        }
        catch (ArgumentException e)
        {
            _debug.SetLabel($"--{e.Message}--");
            return;
        }
        
        SetData();
        UpdateChosenOperation();
        
        _triggerUpdate = true;
    }

    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        var manager = Services.Get<IViewManager>();

        _infoLabel = new LabelUnit("label", "");
        _chooser = new HiddenChooserUnit<Guid>("chooser", "Выбрать операцию");
        
        SetData();
        
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
                new ButtonUnit("create", "Новая операция", () => manager.ChangeView("add_operation")),
                new ButtonUnit("delete", "Удалить операцию", Delete),
                new ButtonUnit("edit", "Изменить операцию", () =>
                {
                    var chosen = GetChosen();

                    if (chosen == null)
                    {
                        _infoLabel.SetLabel("--Нельзя изменить несуществующую операцию--");
                        return;
                    }
                    
                    manager.ChangeView("edit_operation", chosen);
                }),
            }, true),
            new LabelUnit("title", "Просмотр операций:"),
            _chooser,
            new LabelUnit("title2", "Информация о выбранной операции:"),
            _infoLabel,
            _debug,
        ];
        _block = new UnitBlock("block", units);

        _chooser.OnModify = UpdateChosenOperation;
        UpdateChosenOperation();
        
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
