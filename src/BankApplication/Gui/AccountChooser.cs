using BankServices.Bank.DataTransferObjects.BankAccount;
using GuiLibrary.Simple.Choosers;

namespace BankApplication.Gui;

public class AccountChooser : HiddenChooserUnit<Guid>
{
    public AccountChooser(string id, bool isRendering = true) : base(id, "Счёт", null, null, isRendering)
    {
    }
    
    public void SetData(IList<BankAccountData> accounts)
    {
        SetRealValues(accounts.Select(c => c.Id).ToArray());
        SetValues(accounts.Select(c => c.Name).ToArray());
    }
    
    public BankAccountData? GetChosen(IList<BankAccountData> accounts)
    {
        return accounts.FirstOrDefault(x => x.Id == GetRealValue());
    }
}