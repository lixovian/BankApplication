using BankServices.Patterns.Observers.Subscribers;

namespace BankServices.Patterns.Observers;

public class CategoryUpdateObserver :  ICategoryUpdateObserver
{
    private readonly IEnumerable<ICategoryUpdateSubscriber> _subscribers;

    public CategoryUpdateObserver(IEnumerable<ICategoryUpdateSubscriber> subscribers)
    {
        _subscribers = subscribers;
    }

    public void OnCategoryRemove(Guid categoryId)
    {
        foreach (var sub in _subscribers)
        {
            sub.Notify(categoryId);
        }
    }
}