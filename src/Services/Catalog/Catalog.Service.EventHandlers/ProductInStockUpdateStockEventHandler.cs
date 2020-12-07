using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler
        : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;
        private readonly CatalogContext _context;

        public ProductInStockUpdateStockEventHandler(ILogger<ProductInStockUpdateStockEventHandler> logger,
                                                     CatalogContext context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(ProductInStockUpdateStockCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");
            
            var products = command.Items.Select(item => item.ProductId);
            var stocks = await _context.Stock
                         .Where(x => products.Contains(x.ProductId))
                         .ToListAsync(cancellationToken);

            _logger.LogInformation("--- Retrieving products from database");

            foreach (var item in command.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                if(item.Action == ProductInStockAction.Subtract)
                {
                    if(entry is null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"Product {entry.ProductId} - does not have enough stock");
                        throw new ArgumentException($"Product {entry.ProductId} - does not have enough stock");
                    }
                    _logger.LogInformation($"--- Product {entry.ProductId} - stock subtracted - new stock {entry.Stock}");
                    entry.Stock -= item.Stock;
                }
                else
                {
                    if(entry is null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry, cancellationToken);
                        _logger.LogInformation($"--- New Stock created for {entry.ProductId} - because it has not a previous stock");
                    }
                    entry.Stock += item.Stock;
                    _logger.LogInformation($"--- Product {entry.ProductId} - stock increased - new stock {entry.Stock}");
                }
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");
        }
    }
}