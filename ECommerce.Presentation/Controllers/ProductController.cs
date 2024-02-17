using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

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

        /// <summary>
        /// Get all product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            var products = await _service.ProductService.GetAllProductsAsync(productParameters, trackChanges: false);

            return Ok(products);
        }

        /// <summary>
        /// Get product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _service.ProductService.GetProductAsync(id, trackChanges: false);

            return Ok(product);
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {
            if (product is null)
                return BadRequest("ProductForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ModelState.ClearValidationState(nameof(ProductForCreationDto));
            if (!TryValidateModel(product, nameof(ProductForCreationDto)))
                return UnprocessableEntity(ModelState);

            var createdProduct = await _service.ProductService.CreateProductAsync(product);

            return CreatedAtRoute("ProductById", new { id = createdProduct.ProductId }, createdProduct);
        }

        
        

        #endregion

    }
}
