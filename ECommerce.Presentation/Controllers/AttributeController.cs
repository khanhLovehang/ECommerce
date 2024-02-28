using ECommerce.Presentation.ActionFilters;
using ECommerce.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Manager;
using Shared.DataTransferObjects.AttributeDto;
using Shared.RequestFeatures;

namespace ECommerce.Presentation.Controllers
{
    [Route("/api/attributes")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        #region properties
        private readonly IServiceManager _service;
        #endregion

        #region constructor
        public AttributeController(IServiceManager service)
        {
            _service = service;
        }
        #endregion

        #region methods
        /// <summary>
        /// Get all Attributes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAttributes([FromQuery] AttributeParameters attributeParameters)
        {
            var attributes = await _service.AttributeService.GetAllAttributesAsync(attributeParameters, trackChanges: false);

            return Ok(attributes);
        }

        /// <summary>
        /// Get a Attribute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "AttributeById")]
        public async Task<IActionResult> GetAttribute(int id)
        {
            var attribute = await _service.AttributeService.GetAttributeAsync(id, trackChanges: false);

            return Ok(attribute);
        }

        /// <summary>
        /// Create a Attribute
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAttribute([FromBody] AttributeForCreationDto attribute)
        {
            var createdAttribute = await _service.AttributeService.CreateAttributeAsync(attribute);

            return CreatedAtRoute("AttributeById", new { id = createdAttribute.AttributeId }, createdAttribute);
        }

        /// <summary>
        /// Get a collection of Attribute
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("collection/({ids})", Name = "AttributeCollection")]
        public async Task<IActionResult> GetAttributeCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var attributes = await _service.AttributeService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(attributes);
        }

        /// <summary>
        /// Create a collection of Attribute
        /// </summary>
        /// <param name="AttributeCollection"></param>
        /// <returns></returns>
        [HttpPost("collection")]
        public async Task<IActionResult> CreateAttributeCollection([FromBody] IEnumerable<AttributeForCreationDto> attributeCollection)
        {
            var result = await _service.AttributeService.CreateAttributeCollection(attributeCollection);

            return CreatedAtRoute("AttributeCollection", new { result.ids }, result.attributes);
        }

        /// <summary>
        /// Delete Attribute (and its attribute value)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            await _service.AttributeService.DeleteAttributeAsync(id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Update Attribute (while insert child resource - attribute value)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAttribute(int id, [FromBody] AttributeForUpdateDto attribute)
        {
            await _service.AttributeService.UpdateAttributeAsync(id, attribute, trackChanges: true);

            return NoContent();
        }
        #endregion

    }
}
