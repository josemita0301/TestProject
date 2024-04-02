using AppVenta.Domain;
using AppVenta.Domain.Interfaces.Repositories;
using AppVenta.Infrestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Infrestructure.Data.Repositories
{
    public class SaleDetailRepository : IRepositoryDetail<SaleDetail, Guid>
    {
        private SaleContext db;

        public SaleDetailRepository(SaleContext _db)
        {
            db = _db;
        }
        public SaleDetail Add(SaleDetail entity)
        {
            db.SaleDetails.Add(entity);
            return entity;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
