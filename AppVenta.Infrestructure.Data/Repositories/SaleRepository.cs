using AppVenta.Domain;
using AppVenta.Domain.Interfaces.Repositories;
using AppVenta.Infrestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppVenta.Infrestructure.Data.Repositories
{
    public class SaleRepository : IRepositoryMovement<Sale, Guid>
    {
        private SaleContext db;

        public SaleRepository(SaleContext _db)
        {
            db = _db;
        }

        public Sale Add(Sale entity)
        {
            entity.SaleId = Guid.NewGuid();
            db.Sales.Add(entity);
            return entity;
        }

        public List<Sale> List()
        {
            return db.Sales.ToList();
        }

        public void RollbackSale(Guid entityId)
        {
            var selectedSale = db.Sales.Where(c => c.SaleId == entityId).FirstOrDefault();

            if(selectedSale == null)
            {
                throw new NullReferenceException("Esta venta no existe");
            }

            selectedSale.Deleted = true;
            db.Entry(selectedSale).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Sale SelectById(Guid entityId)
        {
            return db.Sales.Where(c => c.SaleId == entityId).FirstOrDefault();
        }
    }
}
