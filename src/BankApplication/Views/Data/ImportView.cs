using BankApplication.Service;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Data.DataTransferObjects;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Data;

public class ImportView : View
{
    private UnitBlock _block = null!;
    private PathInput _fileInput = null!;

    private LabelUnit _infoLabel = null!;

    private void OnClick()
    {
        var importer = Services.Get<IDataHandler<ImportData>>();

        try
        {
            importer.Handle(new ImportData(_fileInput.GetData()));
            _infoLabel.SetLabel("--Импорт данных успешно произведен--");
        }
        catch (ArgumentException e)
        {
            _infoLabel.SetLabel(e.Message);
        }
    }

public override void OnStart(object[] args)
    {
        IViewManager manager = Services.Get<IViewManager>();

        _infoLabel = new LabelUnit("label", $"");
        _fileInput = new PathInput("path", "Введите путь", true);
        
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
                new ButtonUnit("do", "Импортировать данные", OnClick), 
            }, true),
            new LabelUnit("title", "Импорт данных из файла:"),
            _fileInput,
            _infoLabel,
        ];
        _block = new UnitBlock("block", units);
        _block.Update();
    }

    public override void OnIteration(ConsoleKeyInfo key)
    {
        _infoLabel.SetLabel($"--Ожидание ввода--");
        _block.Update(key);
    }
}