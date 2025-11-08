using BankApplication.Gui;
using BankApplication.Service;
using BankApplication.Service.Formatter;
using BankServices.Bank.DataTransferObjects;
using BankServices.Bank.DataTransferObjects.BankAccount;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Patterns.Facades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.BankAccount;

public class BankAccountView : TimeDebugView
{
    private UnitBlock _block = null!;
    private LabelUnit _infoLabel = null!;
    private AccountChooser _chooser = null!;
    

    private IList<BankAccountData> _accounts = null!;
    
    private bool _triggerUpdate;

    private void SetData()
    {
        var facade = Services.Get<BankAccountFacade>();
        _accounts = facade.GetAccounts();
        
        _chooser.SetData(_accounts);
    }
    
    private void UpdateChosenAccount()
    {
        var chosen = _chooser.GetChosen(_accounts);

        if (chosen == null)
        { 
            _debug.SetLabel("--Аккаунт не найден--");
            return;
        }

        var formatter = Services.Get<FormatterFacade>();
        _infoLabel.SetLabel(formatter.FormatAccount(chosen));
    }

    private void Delete()
    {
        var chosen = _chooser.GetChosen(_accounts);

        if (chosen == null)
        { 
            _debug.SetLabel("--Нельзя удалить несуществующий счёт--");
            return;
        }

        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<IDeleteCommand<BankAccountIdentifierData>>();

        try
        {
            handler.Handle(command, new BankAccountIdentifierData(chosen.Id));
        }
        catch (ArgumentException e)
        {
            _debug.SetLabel($"--{e.Message}--");
            return;
        }
        
        SetData();
        UpdateChosenAccount();
        
        _triggerUpdate = true;
    }

    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        var manager = Services.Get<IViewManager>();

        _infoLabel = new LabelUnit("label", "");
        _chooser = new AccountChooser("chooser");

        SetData();

        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
                new ButtonUnit("create", "Новый счёт", () => manager.ChangeView("add_account")),
                new ButtonUnit("delete", "Удалить счёт", Delete),
                new ButtonUnit("edit", "Изменить счёт", () =>
                {
                    var chosen = _chooser.GetChosen(_accounts);

                    if (chosen == null)
                    {
                        _infoLabel.SetLabel("--Нельзя изменить несуществующий счёт--");
                        return;
                    }
                    
                    manager.ChangeView("edit_account", chosen);
                }),
            }, true),
            new LabelUnit("title", "Просмотр счетов:"),
            _chooser,
            new LabelUnit("title2", "Информация о выбранном счёте:"),
            _infoLabel,
            _debug,
        ];
        _block = new UnitBlock("block", units);

        _chooser.OnModify = UpdateChosenAccount;
        UpdateChosenAccount();
        
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