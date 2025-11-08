using BankServices.Bank.DataTransferObjects.Category;

namespace BankServices.Bank.Containers.Category;

public interface ICategoryContainer
{
    public void Add(Objects.Category obj);

    public void Remove(Guid id);

    public IReadOnlyList<Objects.Category> GetAll();

    public void Edit(Objects.Category obj);

    public Objects.Category Get(Guid id);

    public CategoryData GetData(Guid id);

    public IList<CategoryData> GetAllData();
}