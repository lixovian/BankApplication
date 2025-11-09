namespace BankServices.Bank.Realization.Observers.CategoryObserver;

public interface ICategoryUpdateObserver
{

    public void OnCategoryRemove(Guid categoryId);
}