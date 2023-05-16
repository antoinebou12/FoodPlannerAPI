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

    public async Task SeedData(string recipePath, string ingredientPath, string instructionPath, string nutritionInfoPath, string tagPath)
    {
        await ImportFromCsv(recipePath, csv => csv.GetRecords<Recipe>());
        await ImportFromCsv(ingredientPath, csv => csv.GetRecords<Ingredient>());
        await ImportFromCsv(instructionPath, csv => csv.GetRecords<Instruction>());
        await ImportFromCsv(nutritionInfoPath, csv => csv.GetRecords<NutritionInfo>());
        await ImportFromCsv(tagPath, csv => csv.GetRecords<Tag>());

        await _context.SaveChangesAsync();
    }

    private async Task ImportFromCsv<T>(string path, Func<CsvReader, IEnumerable<T>> getRecords) where T : class
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = getRecords(csv).ToList();

        await _context.Set<T>().AddRangeAsync(records);
    }
}
