using BankApplication.Gui;
using BankApplication.Service;
using BankApplication.Service.Formating;
using BankServices.Bank.Connection.Commands;
using BankServices.Bank.Connection.Commands.CommandHandler;
using BankServices.Bank.Data.DataTransferObjects.BankAccount;
using BankServices.Bank.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.BankAccount;

public class BankAccountEditView : TimeDebugView
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private LabelUnit _dataLabel = null!;
    private InputUnit _name = null!;
    
    

    private BankAccountData _editing = null!;
    
    private bool _triggerUpdate;

    private void ParseArgs(object[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("Не передан аккаунт для редактирования");
        }

        try
        { 
            _editing = (BankAccountData) args[0];
        }
        catch (InvalidCastException e)
        {
            throw new ArgumentException("Переданы неверные данные для редактирования");
        }
    }
    
    private void SetInfo()
    {
        var formatter = Services.Get<FormatterFacade>();
        _infoLabel.SetLabel(formatter.FormatAccount(_editing));
    }

    private void Edit()
    {
        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<IEditCommand<BankAccountEditData>>();
        var facade = Services.Get<BankAccountFacade>();

        try
        { 
            handler.Handle(command, new BankAccountEditData(_name.GetData(), _editing.Id));
            _dataLabel.SetLabel("--Изменение произошло успешно--");
        }
        catch (ArgumentException e)
        {
            _dataLabel.SetLabel($"--{e.Message}--"); 
        }

        _editing = facade.GetAccount(_editing.Id);
        
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
                new ButtonUnit("edit", "Изменить счёт", Edit), 
            }, true),
            new LabelUnit("title", "Изменить счёт:"),
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