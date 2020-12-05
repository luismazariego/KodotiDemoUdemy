using System;
using System.Collections.Generic;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            var rnd = new Random();
            IList<Product> products = new List<Product>();
            //var temp = new Product();

            for (int i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"Product {i}",
                    Price = rnd.Next(50,1000),
                    Description = $"Description for Product {i}"
                });
            }

            builder.HasData(products);
        }
    }
}