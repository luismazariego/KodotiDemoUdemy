using System.Threading;
using System.Threading.Tasks;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class ProductInStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductInStockController> _logger;

        public ProductInStockController(IMediator mediator,
                                        ILogger<ProductInStockController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command,
                                                     CancellationToken cancellationToken)
        {
            await _mediator.Publish(command, cancellationToken);
            
            return NoContent();
        }
    }
}