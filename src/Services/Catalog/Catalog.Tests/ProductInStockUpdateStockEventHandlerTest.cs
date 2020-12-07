using System;
using System.Collections.Generic;
using System.Threading;
using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Catalog.Tests
{
    public class ProductInStockUpdateStockEventHandlerTest
    {
        private ILogger<ProductInStockUpdateStockEventHandler> GetLogger
        {
            get => new Mock<ILogger<ProductInStockUpdateStockEventHandler>>()
                   .Object;
        }
        
        [Fact]
        public void Substrac_Should_ReturnNewStock_When_ProductHasEnoughStock()
        {
            //Arrange
            var ctx = CatalogContextInMemory.GetContext();
            int productInStockId = 1;
            int productId = 1;

            //Act
            ctx.Stock.Add(new ProductInStock
            {
                ProductInStockId = productInStockId,
                ProductId = productId,
                Stock = 1
            });

            ctx.SaveChanges();

            var handler = new ProductInStockUpdateStockEventHandler(GetLogger, ctx);

            handler.Handle(new ProductInStockUpdateStockCommand
            {
                Items = new List<ProducInStockUpdateItem>(){
                    new ProducInStockUpdateItem 
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Subtract
                    }
                }
            }, new CancellationToken()).GetAwaiter().GetResult();

            //Assert
            
        }
    }
}
