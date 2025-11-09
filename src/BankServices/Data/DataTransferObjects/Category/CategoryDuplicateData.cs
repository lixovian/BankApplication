namespace BankServices.Data.DataTransferObjects.Category;

public class CategoryDuplicateData : IDataTransferObject
{
    public CategoryData Main { get; private set; }
    public string NewName { get; private set; }

    public CategoryDuplicateData(CategoryData main, CategoryEditData data)
    {
        Main = main;
        NewName = data.Name;
    }
}