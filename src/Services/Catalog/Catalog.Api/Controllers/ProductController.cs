using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Service.Queries.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Common.Collection;
using System;
using Catalog.Service.Queries;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using System.Threading;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger,
                                 IProductQueryService productQueryService, 
                                 IMediator mediator)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take=10, string ids = null)
        {
            IEnumerable<int> products = null;
            
            if (ids is not null)
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService.GetAllAsync(page, take, products);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Publish(command, cancellationToken);

            return Ok();
        }
    }
}