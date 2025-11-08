namespace BankServices.Patterns.Observers.Subscribers;

public interface ICategoryUpdateSubscriber
{
    public void Notify(Guid removed);
}