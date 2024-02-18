using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ECommerce.Presentation.Controllers
{
    [Route("/api/products/{productId}/attribute-values")]
    [ApiController]
    public class AttributeValueController : ControllerBase
    {
        #region properties
        private readonly IServiceManager _service;
        #endregion

        #region constructor
        public AttributeValueController(IServiceManager service)
        {
            _service = service;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get list attribute
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAttributeValues(Guid productId)
        {
            var attributesValue = await _service.AttributeValueService.GetAttributeValues(productId, trackChanges: false);

            return Ok(attributesValue);
        }

        /// <summary>
        /// Get detail attribute
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetAttributeValueForProduct")]
        public async Task<IActionResult> GetAttributeValue(Guid productId, int id)
        {
            var attributeValue = await _service.AttributeValueService.GetAttributeValue(productId, id, trackChanges: false);

            return Ok(attributeValue);
        }

        /// <summary>
        /// Create attribute value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAttributeValueForProduct(Guid productId, [FromBody] AttributeValueForCreationDto attributeValue)
        {
            if (attributeValue is null)
                return BadRequest("AttributeValueForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ModelState.ClearValidationState(nameof(AttributeValueForCreationDto));
            if (!TryValidateModel(attributeValue, nameof(AttributeValueForCreationDto)))
                return UnprocessableEntity(ModelState);

            var attributeValueReturn = await _service.AttributeValueService.CreateAttributeValueForProductAsync(productId, attributeValue, trackChanges: false);

            return CreatedAtRoute("GetAttributeValueForProduct", new { productId, id = attributeValueReturn.AttributeValueId }, attributeValueReturn);

            //return Ok(createdAttributeValueProduct);
        }
        #endregion

    }
}
