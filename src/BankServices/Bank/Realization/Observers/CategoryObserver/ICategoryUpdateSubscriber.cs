namespace BankServices.Bank.Realization.Observers.CategoryObserver;

public interface ICategoryUpdateSubscriber
{
    public void Notify(Guid removed);
}