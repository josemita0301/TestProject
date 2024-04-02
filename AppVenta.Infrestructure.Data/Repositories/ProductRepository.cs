using AppVenta.Domain;
using AppVenta.Domain.Interfaces.Repositories;
using AppVenta.Infrestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppVenta.Infrestructure.Data.Repositories
{
    public class ProductRepository : IRepositoryBase<Product, Guid>
    {
        private SaleContext db;

        public ProductRepository(SaleContext _db)
        {
            db = _db;
        }

        public Product Add(Product entity)
        {
            entity.ProductId = Guid.NewGuid();
            db.Products.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var selectedProduct = db.Products.Where(c => c.ProductId == entityId).FirstOrDefault();

            if (selectedProduct != null)
            {
                db.Remove(selectedProduct);
            }
        }

        public void Edit(Product entity)
        {
            var selectedProduct = db.Products.Where(c => c.ProductId == entity.ProductId).FirstOrDefault();

            if(selectedProduct != null)
            {
                selectedProduct.Name = entity.Name;
                selectedProduct.Description = entity.Description;
                selectedProduct.Cost = entity.Cost;
                selectedProduct.Price = entity.Price;
                selectedProduct.StockQuantity = entity.StockQuantity;
            }

            db.Entry(selectedProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Product> List()
        {
            return db.Products.ToList();
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Product SelectById(Guid entityId)
        {
            return db.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
        }
    }
}
