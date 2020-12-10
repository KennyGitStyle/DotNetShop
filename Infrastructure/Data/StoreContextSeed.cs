using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try {
                if(!context.ProductBrands.Any()){
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    brands.ForEach(b => context.ProductBrands.Add(b));

                    // foreach (var item in brands)
                    // {
                    //     context.ProductBrands.Add(item);
                    // }

                    await context.SaveChangesAsync();
                }
                
                if(!context.ProductTypes.Any()){
                    var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    types.ForEach(t => context.ProductTypes.Add(t));

                    // foreach (var item in types)
                    // {
                    //     context.ProductTypes.Add(item);
                    // }

                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any()){
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    products.ForEach(p => context.Products.Add(p));

                    // foreach (var item in products)
                    // {
                    //     context.Products.Add(item);
                    // }

                    await context.SaveChangesAsync();
                }
            } catch(Exception ex){

                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                
                logger.LogError("Store Context Error...", ex.Message);
            }
        }
    }
}