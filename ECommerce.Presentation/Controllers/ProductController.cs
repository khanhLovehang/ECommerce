using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Controllers
{
    [Route("/api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region properties
        private readonly IServiceManager _service;
        #endregion

        #region constructor
        public ProductController(IServiceManager service)
        {
            _service = service;
        }
        #endregion

        #region methods

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _service.ProductService.GetAllProducts(trackChanges: false);
            return Ok(products);
        }

        [HttpGet("{id:guid}", Name = "ProductById")]
        public IActionResult GetAllProducts(Guid id)
        {
            var product = _service.ProductService.GetProduct(id, trackChanges: false);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreationDto product)
        {
            if (product is null)
                return BadRequest("ProductForCreationDto object is null");

            var createdProduct = _service.ProductService.CreateProduct(product);

            return CreatedAtRoute("ProductById", new {id = createdProduct.ProductId }, createdProduct);
        }
        #endregion

    }
}
