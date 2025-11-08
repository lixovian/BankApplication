namespace BankServices.Patterns.Observers;

public interface ICategoryUpdateObserver
{

    public void OnCategoryRemove(Guid categoryId);
}