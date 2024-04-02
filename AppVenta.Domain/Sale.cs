using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Domain
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public long SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string Concept { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public bool Deleted { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }

    }
}
