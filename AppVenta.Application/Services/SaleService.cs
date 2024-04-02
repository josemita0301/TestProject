using AppVenta.Application.Interfaces;
using AppVenta.Domain;
using AppVenta.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Application.Services
{
    public class SaleService : IMovementService<Sale, Guid>
    {
        IRepositoryMovement<Sale, Guid> SaleRepository;
        IRepositoryBase<Product, Guid> ProductRepository;
        IRepositoryDetail<SaleDetail, Guid> DetailRepository;

        public SaleService(IRepositoryMovement<Sale, Guid> saleRepository,
        IRepositoryBase<Product, Guid> productRepository,
        IRepositoryDetail<SaleDetail, Guid> saleDetailRepository)
        {
            SaleRepository = saleRepository;
            ProductRepository = productRepository;
            DetailRepository = saleDetailRepository;
        }  

        public Sale Add(Sale entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The Sale is needed");

            var addedSale = SaleRepository.Add(entity);

            entity.SaleDetails.ForEach(detail => {
                var selectedProduct = ProductRepository.SelectById(detail.ProductId);
                if (selectedProduct == null)
                    throw new ArgumentNullException("The product you are trying to sale is not available");

                detail.SaleId = addedSale.SaleId;
                detail.ProductId = selectedProduct.ProductId;
                detail.UnitCost = selectedProduct.Cost;
                detail.UnitPrice = selectedProduct.Price;
                detail.SoldQuantity = detail.SoldQuantity;
                detail.Subtotal = detail.UnitPrice * detail.SoldQuantity;
                detail.Tax = detail.Subtotal * (15 / 100);
                detail.Total = detail.Subtotal + detail.Tax;
                DetailRepository.Add(detail);
                
                selectedProduct.StockQuantity -= detail.SoldQuantity;
                ProductRepository.Edit(selectedProduct);               

                entity.Subtotal += detail.Subtotal;
                entity.Tax += detail.Tax;
                entity.Total += detail.Total;
            });
            
            SaleRepository.SaveAllChanges();
            return entity;
        }

        public List<Sale> List()
        {
            return SaleRepository.List();
        }

        public void RollbackMovement(Guid entityId)
        {
            SaleRepository.RollbackSale(entityId);
            SaleRepository.SaveAllChanges();
        }

        public Sale SelectById(Guid entityId)
        {
            return SaleRepository.SelectById(entityId);
        }
    }
}
