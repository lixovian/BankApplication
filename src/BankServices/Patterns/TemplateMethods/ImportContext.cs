using BankServices.Patterns.Facades;

namespace BankServices.Patterns.TemplateMethods;

public class ImportContext : IImportContext
{
    private readonly IEnumerable<DataImporter> _importers;

    public ImportContext(IEnumerable<DataImporter> importers)
    {
        _importers = importers;
    }

    public void Import(string path, BankAccountFacade accountsFacade, CategoryFacade categoriesFacade,
        OperationFacade operationsFacade)
    {
        var importer = _importers.FirstOrDefault(i => i.CanImport(path));

        if (importer == null)
        {
            throw new ArgumentException("Неподдерживаемый тип файлов");
        }
        
        try
        {
            importer.Import(path, accountsFacade, categoriesFacade, operationsFacade);
        }
        catch (NullReferenceException e)
        {
            throw new ArgumentException(e.Message);
        }
        catch (FileNotFoundException e)
        {
            throw new ArgumentException(e.Message);
        }
        catch (IOException e)
        {
            throw new ArgumentException(e.Message);
        }
        catch (FormatException e)
        {
            throw new ArgumentException(e.Message);
        }
    }
}