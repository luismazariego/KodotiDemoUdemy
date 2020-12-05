using Catalog.Persistence.Database;

namespace Catalog.Service.Queries
{
    public class ProductQueryService
    {
        private readonly CatalogContext _context;

        public ProductQueryService(CatalogContext context)
        {
            _context = context;
        }

        
    }
}