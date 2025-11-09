using BankApplication.Gui;
using BankApplication.Service;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Data.DataTransferObjects.BankAccount;
using BankServices.Data.DataTransferObjects.Category;
using BankServices.Data.DataTransferObjects.Operation;
using BankServices.Realization.DomainFacades;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Operation;

public class OperationCreateView : TimeDebugView
{
    private UnitBlock _block = null!;

    private ValueInput<decimal> _input = null!;
    private TransactionChooser _transactionChooser = null!;
    private AccountChooser _accountChooser = null!;
    private InputUnit _descriptionInput = null!;
    private CategoryChooser _categoryChooser = null!;
    

    private LabelUnit _label = null!;
    
    private IList<BankAccountData> _accounts = null!;
    private IList<CategoryData?> _categories = null!;

    private bool _shouldUpdate;
    
    private void SetData()
    {
        var facade = Services.Get<CategoryFacade>();
        _categories = facade.GetCategories()!;
        _categories.Insert(0, null);
        
        _categoryChooser.SetData(_categories);
        
        var facade2 = Services.Get<BankAccountFacade>();
        _accounts = facade2.GetAccounts();
        
        _accountChooser.SetData(_accounts);
    }
    
    private void Add()
    {
        if (_accountChooser.GetRealValue() == Guid.Empty)
        {
            _label.SetLabel("--Счёт не существует--");
            return;
        }
        
        var handler = Services.Get<ICommandHandler>();
        var command = Services.Get<ICreateCommand<OperationRequiredData>>();

        try
        {
            // Собираем данные из GUI
            if (!_input.GetConvertedValue(out var amount))
            {
                _label.SetLabel("--Неверная сумма перевода--");
                return;
            }

            var type = _transactionChooser.GetRealValue();
            var accountId = _accountChooser.GetRealValue();
            var description = _descriptionInput.GetData();
            var categoryId = _categoryChooser.GetRealValue();

            var data = new OperationRequiredData(type, accountId, amount, description, categoryId);

            handler.Handle(command, data);
            _label.SetLabel("--Операция добавлена успешно--");
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
        _descriptionInput.SetData("");
        _input.SetData("");
        _transactionChooser.SetValueIndex(0);
        _accountChooser.SetValueIndex(0);
        _categoryChooser.SetValueIndex(0);
    }

    public override void OnStart(object[] args)
    {
        base.OnStart(args);
        
        var manager = Services.Get<IViewManager>();

        _input = new ValueInput<decimal>("amount", "Сумма операции");
        _transactionChooser = new TransactionChooser("type");
        _accountChooser = new AccountChooser("account");
        _descriptionInput = new InputUnit("description", "Описание операции");
        _categoryChooser = new CategoryChooser("category");
        _label = new LabelUnit("condition", "--Ожидание добавления--");

        SetData();
        
        List<Unit> units =
        [
            new LabelUnit("label", "Введите данные об операции:"),
            _input,
            _transactionChooser,
            _accountChooser,
            _categoryChooser,
            _descriptionInput,
            new UnitBlock("buttons", new Unit[]
            {
                new ButtonUnit("add", "Создать операцию", Add),
                new ButtonUnit("back", "Вернуться назад", () => manager.ChangeView("operations"))
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