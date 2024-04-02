using AppVenta.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Infrestructure.Data.Configs
{
    class SaleDetailConfig : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SALE_DETAIL");
            builder.HasKey(c => new { c.ProductId, c.SaleId});

            builder
                .HasOne(detail => detail.Product)
                .WithMany(product => product.SaleDetails);

            builder
                .HasOne(detail => detail.Sale)
                .WithMany(sale => sale.SaleDetails);
        }
    }
}
