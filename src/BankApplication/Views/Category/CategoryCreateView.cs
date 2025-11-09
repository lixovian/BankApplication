using BankApplication.Gui;
using BankApplication.Service;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.Objects.Service;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Choosers;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Category;

public class CategoryCreateView : TimeDebugView
{
    private UnitBlock _block = null!;

    private InputUnit _nameInput = null!;
    private HiddenChooserUnit<TransactionType> _transactionChooser = null!;
    private LabelUnit _label = null!;
    

    private bool _shouldUpdate;

    private void Add()
    {
        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<ICreateCommand<CategoryRequiredData>>();

        try
        {
            handler.Handle(command, new CategoryRequiredData(_nameInput.GetData(), _transactionChooser.GetRealValue()));
            _label.SetLabel("--Категория добавлена успешно--");
        }
        catch (ArgumentException e)
        {
            _label.SetLabel($"--{e.Message}--");
        }

        Clear();
        _shouldUpdate = true;
    }

    private void Clear()
    {
        _nameInput.SetData("");
        _transactionChooser.SetValueIndex(0);
    }

    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        IViewManager manager = Services.Get<IViewManager>();

        _nameInput = new InputUnit("name", "Название");
        _transactionChooser = new TransactionChooser("type");
        _label = new LabelUnit("condition", "--Ожидание добавления--");

        List<Unit> units =
        [
            new LabelUnit("label", "Введите данные о категории:"),
            _nameInput,
            _transactionChooser,
            new UnitBlock("buttons", new Unit[]
            {
                new ButtonUnit("add", "Создать категорию", Add),
                new ButtonUnit("back", "Вернуться назад", () => manager.ChangeView("categories"))
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

        if (_shouldUpdate)
        {
            Console.Clear();
            _block.Update();

            _shouldUpdate = false;
        }
    }
}