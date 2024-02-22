using ECommerce.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetAttributeValuesForProduct(Guid productId)
        {
            var attributeValues = await _service.AttributeValueService.GetAttributeValuesAsync(productId, trackChanges: false);

            return Ok(attributeValues);
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
            var attributeValue = await _service.AttributeValueService.GetAttributeValueAsync(productId, id, trackChanges: false);

            return Ok(attributeValue);
        }

        /// <summary>
        /// Create attribute value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAttributeValueForProduct(Guid productId, [FromBody] AttributeValueForCreationDto attributeValue)
        {
            var attributeValueReturn = await _service.AttributeValueService.CreateAttributeValueForProductAsync(productId, attributeValue, trackChanges: false);

            return CreatedAtRoute("GetAttributeValueForProduct", new { productId, id = attributeValueReturn.AttributeValueId }, attributeValueReturn);
        }

        /// <summary>
        /// Delete attribute value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAttributeValueForProduct(Guid productId, int id)
        {
            await _service.AttributeValueService.DeleteAttributeValueForProduct(productId, id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Update attribute value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAttributeValueForProduct(Guid productId, int id, [FromBody] AttributeValueForUpdateDto attributeValue)
        {
            await _service.AttributeValueService.UpdateAttributeValueForProduct(productId, id, attributeValue, proTrackChanges: false, attrTrackChanges: true);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateAttributeValueForProduct(Guid productId, int id, [FromBody] JsonPatchDocument<AttributeValueForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.AttributeValueService.GetAttributeValueForPatch(productId, id, proTrackChanges: false, attrTrackChanges: true);

            patchDoc.ApplyTo(result.attributeValueToPatch);

            await _service.AttributeValueService.SaveChangesForPatch(result.attributeValueToPatch, result.attributeValueEntity);

            return NoContent();
        }


        #endregion

    }
}
