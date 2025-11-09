using BankServices.Data.Objects.Service;
using GuiLibrary.Simple.Choosers;

namespace BankApplication.Gui;

public class TransactionChooser : HiddenChooserUnit<TransactionType>
{
    public TransactionChooser(string id,
        bool isRendering = true) : base(id, "Тип транзакции", [TransactionType.Income, TransactionType.Expense], ["Доход", "Расход"], isRendering)
    {
    }
}