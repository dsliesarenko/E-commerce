using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    await AddDataFromJsonFile(context, context.ProductBrands, "Brands");
                }

                if (!context.ProductTypes.Any())
                {
                    await AddDataFromJsonFile(context, context.ProductTypes, "Types");
                }

                if (!context.Products.Any())
                {
                    await AddDataFromJsonFile(context, context.Products, "Products");
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }

        private static async Task AddDataFromJsonFile<T>(StoreContext context, DbSet<T> table, string filename) where T : class
        {
            var data = File.ReadAllText($"../Infrastructure/Data/SeedData/{filename}.json");

            var items = JsonSerializer.Deserialize<List<T>>(data);

            foreach (var item in items)
            {
                table.Add(item);
            }

            await context.SaveChangesAsync();
        }
    }
}
