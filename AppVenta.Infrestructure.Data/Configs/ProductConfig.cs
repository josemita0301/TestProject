using AppVenta.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Infrestructure.Data.Configs
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(c => c.ProductId);

            builder
                .HasMany(product => product.SaleDetails)
                .WithOne(saleDetail => saleDetail.Product);
        }
    }
}
