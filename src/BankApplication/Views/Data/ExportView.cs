using BankApplication.Service;
using BankServices.Bank.DataTransferObjects;
using BankServices.Connection.Commands;
using BankServices.Connection.Commands.CommandHandler;
using BankServices.Objects.Service;
using GuiLibrary.Assembled;
using GuiLibrary.Base;
using GuiLibrary.Simple;
using GuiLibrary.Simple.Choosers;
using GuiLibrary.Simple.Inputs;
using ViewManagerLibrary;
using ViewManagerLibrary.ViewManager;

namespace BankApplication.Views.Data;

public class ExportView : View
{
    private UnitBlock _block = null!;
    private PathInput _fileInput = null!;
    private HiddenChooserUnit<FileType> _typeChooser = null!;

    private LabelUnit _infoLabel = null!;

    private void OnClick()
    {
        var exporter = Services.Get<IDataHandler<ExportData>>();

        try
        {
            exporter.Handle(new ExportData(_fileInput.GetData(), _typeChooser.GetRealValue()));
            _infoLabel.SetLabel("--Экспорт данных успешно произведен--");
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
        _fileInput = new PathInput("path", "Введите путь", false);
        _typeChooser = new HiddenChooserUnit<FileType>("type", "Тип файла", 
            [FileType.Csv, FileType.Json, FileType.Yaml], ["CSV", "JSON", "YAML"]);
        
        List<Unit> units =
        [
            new UnitBlock("buttons", new Unit[] 
            { 
                new ButtonUnit("back", "Назад", () => manager.ChangeView("menu")), 
                new ButtonUnit("do", "Экспортировать данные", OnClick), 
            }, true),
            new LabelUnit("title", "Экспорт данных из файла:"),
            _fileInput,
            _typeChooser,
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