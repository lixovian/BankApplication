namespace BankServices.Bank.DataTransferObjects.Operation;

public class OperationDuplicateData : IDataTransferObject
{
    public OperationData Main { get; private set; }
    public string NewDescription { get; private set; }
    public Guid? NewCategoryId { get; private set; }
    
    public OperationDuplicateData(OperationData main, OperationEditData data)
    {
        Main = main;
        NewDescription = data.Description;
        NewCategoryId = data.CategoryId;
    }
}