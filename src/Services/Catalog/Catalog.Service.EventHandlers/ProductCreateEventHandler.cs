using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;

namespace Catalog.Service.EventHandlers
{
    public class ProductCreateEventHandler 
        : INotificationHandler<ProductCreateCommand>
    {
        private readonly CatalogContext _context;

        public ProductCreateEventHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreateCommand command, 
                                 CancellationToken cancellationToken
                                 )
        {
            await _context.AddAsync(new Product
                {
                    Price = command.Price,
                    Description = command.Description,
                    Name = command.Name
                }, 
                cancellationToken)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken)
                  .ConfigureAwait(false);
        }
    }
}