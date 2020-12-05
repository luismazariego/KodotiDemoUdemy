using System;
using System.Collections.Generic;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<ProductInStock>
    {
        public void Configure(EntityTypeBuilder<ProductInStock> builder)
        {
            builder.HasKey(x => x.ProductInStockId);

            var rnd = new Random();
            IList<ProductInStock> stock = new List<ProductInStock>();
            

            for (int i = 1; i <= 100; i++)
            {
                stock.Add(new ProductInStock
                {
                    ProductId = i,
                    ProductInStockId = i,
                    Stock = rnd.Next(0, 100)
                });
            }

            builder.HasData(stock);
        }
    }
}