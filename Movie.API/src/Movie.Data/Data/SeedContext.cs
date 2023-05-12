using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Movie.Domain.Models.Lookups;

namespace Movie.Data.Data
{
    public class SeedContext
    {
        public static async Task SeedAsync(MovieDataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Types.Any())
                {
                    var movieTypesData =
                        File.ReadAllText("../Movie.Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<TypeLookup>>(movieTypesData);
                    foreach (var item in types)
                    {
                        context.Types.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedContext>();
                logger.LogError(ex.Message);
            }
        }

    }
}
