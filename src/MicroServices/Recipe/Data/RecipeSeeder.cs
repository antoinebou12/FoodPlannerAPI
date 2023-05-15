using System.ComponentModel.DataAnnotations;
using CsvHelper;
using System.Globalization;

public class RecipeSeeder
{
    private readonly RecipeContext _context;

    public RecipeSeeder(RecipeContext context)
    {
        _context = context;
    }

    public async Task SeedData(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<Recipe>().ToList();

        foreach (var record in records)
        {
            _context.Recipes.Add(record);
        }

        await _context.SaveChangesAsync();
    }

    private void ImportFromCsv(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<Recipe>().ToList();

        foreach (var record in records)
        {
            _context.Recipes.Add(record);
        }
    }
}