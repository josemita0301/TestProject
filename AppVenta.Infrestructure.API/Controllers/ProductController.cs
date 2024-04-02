using AppVenta.Application.Services;
using AppVenta.Domain;
using AppVenta.Infrestructure.Data.Context;
using AppVenta.Infrestructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppVenta.Infrestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService CreateService()
        {
            SaleContext db = new SaleContext();
            ProductRepository productRepository = new ProductRepository(db);
            ProductService productService = new ProductService(productRepository);
            return productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var service = CreateService();
            return Ok(service.List());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var service = CreateService();
            service.Add(product);
            return Ok("Producto agregado!!!");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Product product)
        {
            var service = CreateService();
            service.Edit(product);
            return Ok("Producto editado!!!");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Producto borrado!!!");
        }
    }
}
