using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Services.Common.Collection;
using Services.Common.Mapping;
using Services.Common.Paging;

namespace Catalog.Service.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDto> GetAsync(int id);
    }

    public class ProductQueryService : IProductQueryService
    {
        private readonly CatalogContext _context;

        public ProductQueryService(CatalogContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductDto>> GetAllAsync(
            int page,
            int take,
            IEnumerable<int> products = null)
        {
            DataCollection<Product> collection = await
                    _context.Products
                    .Where(p => products == null || products.Contains(p.ProductId))
                    .OrderByDescending(x => x.ProductId)
                    .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            return (
                    await _context.Products
                    .SingleOrDefaultAsync(x => x.ProductId == id)
                   ).MapTo<ProductDto>();
        }
    }
}