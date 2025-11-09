using BankApplication.Gui;
using BankApplication.Service;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Data.DataTransferObjects.BankAccount;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.BankAccount;

public class BankAccountCreateView : TimeDebugView
{
    private UnitBlock _block = null!;

    private InputUnit _nameInput = null!;
    private LabelUnit _label = null!;


    private void Add()
    {
        var command = Services.Get<ICreateCommand<BankAccountRequiredData>>();
        var handler = Services.Get<ICommandHandler>();

        try
        {
            handler.Handle(command, new BankAccountRequiredData(_nameInput.GetData()));
            _label.SetLabel("--Счёт добавлен успешно--");
        }
        catch (ArgumentException e)
        {
            _label.SetLabel($"--{e.Message}--");
        }
    }

    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        IViewManager manager = Services.Get<IViewManager>();

        _nameInput = new InputUnit("name", "Название");
        _label = new LabelUnit("condition", "--Ожидание добавления--");
        
        List<Unit> units =
        [
            new LabelUnit("label", "Введите данные о счёте:"),
            _nameInput,
            new UnitBlock("buttons", new Unit[]
            {
                new ButtonUnit("add", "Создать счёт", Add),
                new ButtonUnit("back", "Вернуться назад", () => manager.ChangeView("accounts"))
            }, true),
            _label,
            _debug,
        ];

        _block = new UnitBlock("block", units);

        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        base.OnIteration(key);
        
        _label.SetLabel("--Ожидание добавления--");
        _block.Update(key);
    }
}