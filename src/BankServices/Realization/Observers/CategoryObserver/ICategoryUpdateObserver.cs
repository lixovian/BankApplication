namespace BankServices.Realization.Observers.CategoryObserver;

public interface ICategoryUpdateObserver
{

    public void OnCategoryRemove(Guid categoryId);
}