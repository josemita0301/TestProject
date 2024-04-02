using AppVenta.Application.Services;
using AppVenta.Domain;
using AppVenta.Infrestructure.Data.Context;
using AppVenta.Infrestructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVenta.Infrestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        SaleService CreateService()
        {
            SaleContext db = new SaleContext();
            SaleRepository saleRepository = new SaleRepository(db);
            SaleDetailRepository saleDetailRepository = new SaleDetailRepository(db);
            ProductRepository productRepository = new ProductRepository(db);
            SaleService saleService = new SaleService(saleRepository, productRepository, saleDetailRepository);
            return saleService;
        }

        // GET: api/<SaleController>
        [HttpGet]
        public ActionResult<List<Sale>> Get()
        {
            var service = CreateService();
            return Ok(service.List());
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public ActionResult<Sale> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectById(id));
        }

        // POST api/<SaleController>
        [HttpPost]
        public ActionResult Post([FromBody] Sale sale)
        {
            var service = CreateService();
            service.Add(sale);
            return Ok("Venta agregado!!!");
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.RollbackMovement(id);
            return Ok("Venta anulada!!!");
        }
    }
}
