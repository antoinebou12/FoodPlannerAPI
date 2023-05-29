using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Recipe.Data
{
    public class RecipeSeeder
    {
        private readonly RecipeContext _context;

        public RecipeSeeder(RecipeContext context)
        {
            _context = context;
        }

        // Main seeding method
        public async Task SeedData(string recipePath, string ingredientPath, string instructionPath, string nutritionInfoPath, string tagPath)
        {
            await ImportFromCsv<Recipe>(recipePath, csv => csv.GetRecords<Recipe>());
            await ImportFromCsv<Ingredient>(ingredientPath, csv => csv.GetRecords<Ingredient>());
            await ImportFromCsv<Instruction>(instructionPath, csv => csv.GetRecords<Instruction>());
            await ImportFromCsv<NutritionInfo>(nutritionInfoPath, csv => csv.GetRecords<NutritionInfo>());
            await ImportFromCsv<Tag>(tagPath, csv => csv.GetRecords<Tag>());

            await _context.SaveChangesAsync();
        }

        // Helper method to import data from CSV files
        private async Task ImportFromCsv<T>(string path, Func<CsvReader, IEnumerable<T>> getRecords) where T : class
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = getRecords(csv).ToList();

            await _context.Set<T>().AddRangeAsync(records);
        }
    }
}
