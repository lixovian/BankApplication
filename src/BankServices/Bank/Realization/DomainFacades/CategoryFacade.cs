using BankServices.Bank.Data.Containers.Category;
using BankServices.Bank.Data.DataTransferObjects.Category;
using BankServices.Bank.Data.Objects;
using BankServices.Bank.Realization.DomainFabrics;
using BankServices.Bank.Realization.Observers.CategoryObserver;

namespace BankServices.Bank.Realization.DomainFacades;

public class CategoryFacade
{
    private readonly IObjectFabric<Category, CategoryRequiredData> _fabric;
    private readonly IObjectFabric<Category, CategoryDuplicateData> _fabricDuplicator;
    private readonly ICategoryContainer _categoriesContainer;
    private readonly ICategoryUpdateObserver _observer;
    
    private readonly IObjectFabric<Category, CategoryData> _retrieveFabric;

    public CategoryFacade(ICategoryContainer categoriesContainer,
        IObjectFabric<Category, CategoryRequiredData> fabric,
        IObjectFabric<Category, CategoryDuplicateData> fabricDuplicator, ICategoryUpdateObserver observer, IObjectFabric<Category, CategoryData> categoryFabric)
    {
        _categoriesContainer = categoriesContainer;
        _fabric = fabric;
        _fabricDuplicator = fabricDuplicator;
        _observer = observer;
        _retrieveFabric = categoryFabric;
    }

    public void CreateCategory(CategoryRequiredData data)
    {
        _categoriesContainer.Add(_fabric.Create(data));
    }
    
    public void AddCategory(CategoryData data)
    {
        _categoriesContainer.Add(_retrieveFabric.Create(data));
    }

    public void EditCategory(CategoryEditData data)
    {
        var baseData = _categoriesContainer.GetData(data.Id);
        var clone = _fabricDuplicator.Create(new CategoryDuplicateData(baseData, data));
        _categoriesContainer.Edit(clone);
    }

    public void DeleteCategory(CategoryIdentifierData data)
    {
        _categoriesContainer.Remove(data.Id);
        _observer.OnCategoryRemove(data.Id);
    }

    public IList<CategoryData> GetCategories()
    {
        return _categoriesContainer.GetAllData();
    }

    public CategoryData GetCategory(Guid categoryId)
    {
        return _categoriesContainer.GetData(categoryId);
    }
}