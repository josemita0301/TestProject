using AppVenta.Application.Interfaces;
using AppVenta.Domain;
using AppVenta.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Application.Services
{
    public class ProductService : IBaseService<Product, Guid>
    {
        private readonly IRepositoryBase<Product, Guid> ProductRepository;
        public ProductService(IRepositoryBase<Product, Guid> productRepository)
        {
            ProductRepository = productRepository;
        }

        public Product Add(Product entity)
        {
            if(entity == null)
                throw new ArgumentNullException("The Product is needed");

            var resutProduct = ProductRepository.Add(entity);
            ProductRepository.SaveAllChanges();
            return resutProduct;
        }

        public void Delete(Guid entityId)
        {
            ProductRepository.Delete(entityId);
            ProductRepository.SaveAllChanges();
        }

        public void Edit(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The Product is needed");

            ProductRepository.Edit(entity);
            ProductRepository.SaveAllChanges();
        }

        public List<Product> List()
        {
            return ProductRepository.List();
        }

        public Product SelectById(Guid entityId)
        {
            return ProductRepository.SelectById(entityId);
        }
    }
}
