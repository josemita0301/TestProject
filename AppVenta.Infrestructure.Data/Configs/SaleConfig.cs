using AppVenta.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Infrestructure.Data.Configs
{
    class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("SALE");
            builder.HasKey(c => c.SaleId);

            builder
                .HasMany(sale => sale.SaleDetails)
                .WithOne(saleDetail => saleDetail.Sale);
        }
    }
}
