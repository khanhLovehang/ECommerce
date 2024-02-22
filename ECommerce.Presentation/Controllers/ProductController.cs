using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using ECommerce.Presentation.ModelBinders;
using ECommerce.Presentation.ActionFilters;

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
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            var products = await _service.ProductService.GetAllProductsAsync(productParameters, trackChanges: false);

            return Ok(products);
        }

        /// <summary>
        /// Get a product
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
        /// Create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {
            var createdProduct = await _service.ProductService.CreateProductAsync(product);

            return CreatedAtRoute("ProductById", new { id = createdProduct.ProductId }, createdProduct);
        }

        /// <summary>
        /// Get a collection of product
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("collection/({ids})", Name = "ProductCollection")]
        public async Task<IActionResult> GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var products = await _service.ProductService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(products);
        }

        /// <summary>
        /// Create a collection of product
        /// </summary>
        /// <param name="productCollection"></param>
        /// <returns></returns>
        [HttpPost("collection")]
        public async Task <IActionResult> CreateProductCollection([FromBody] IEnumerable<ProductForCreationDto> productCollection)
        {
            var result = await _service.ProductService.CreateProductCollection(productCollection);

            return CreatedAtRoute("ProductCollection", new { result.ids }, result.products);
        }

        /// <summary>
        /// Delete product (and its attribute value)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
           await _service.ProductService.DeleteProductAsync(id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Update product (while insert child resource - attribute value)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto product)
        {
            await _service.ProductService.UpdateProductAsync(id, product, trackChanges: true);

            return NoContent();
        }


        #endregion

    }
}
