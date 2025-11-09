using BankServices.Data.DataTransferObjects.Category;

namespace BankServices.Data.Containers.Category;

public class CategoryContainer : ICategoryContainer
{
    private readonly List<Objects.Category> _data = new();

    public void Add(Objects.Category obj)
    {
        _data.Add(obj);
    }

    public void Remove(Guid id)
    {
        var obj = Get(id);

        _data.Remove(obj);
    }

    public IReadOnlyList<Objects.Category> GetAll()
    {
        return _data;
    }

    public void Edit(Objects.Category obj)
    {
        var index = _data.FindIndex(c => c.Id == obj.Id);
        _data[index] = obj;
    }

    public Objects.Category Get(Guid id)
    {
        var obj = _data.FirstOrDefault(x => x.Id == id);
        if (obj == null)
        {
            throw new ArgumentException($"Не найдена категория");
        }
        return obj;
    }

    public CategoryData GetData(Guid id)
    {
        var obj = Get(id);
        return new CategoryData(obj);
    }

    public IList<CategoryData> GetAllData()
    {
        return _data.Select(x => new CategoryData(x)).ToList();
    }
}