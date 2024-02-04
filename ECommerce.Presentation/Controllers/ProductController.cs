using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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

        //[HttpGet]
        //public IActionResult GetAllProducts()
        //{
        //    try
        //    {
        //        var products = _service.ProductService.GetAllProducts(trackChanges: false);
        //        return products;
        //    }
        //    catch 
        //    {

        //        return StatusCode(500, "Internal server error");
        //    }
        //}
        #endregion

    }
}
