using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Tests.Config
{
    public static class CatalogContextInMemory
    {
        public static CatalogContext GetContext()
        {
            var options = new DbContextOptionsBuilder<CatalogContext>()
                          .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                          .Options;

            return new CatalogContext(options);
        }

        
    }
}