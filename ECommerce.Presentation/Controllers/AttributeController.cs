using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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
        /// Thêm thuộc tính
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAttribute([FromBody] AttributeForCreationDto attribute)
        {
            if (attribute is null)
                return BadRequest("AttributeForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ModelState.ClearValidationState(nameof(AttributeForCreationDto));
            if (!TryValidateModel(attribute, nameof(AttributeForCreationDto)))
                return UnprocessableEntity(ModelState);

            var createdAttribute = await _service.AttributeService.CreateAttributeAsync(attribute);

            return CreatedAtRoute("AttributeById", new { id = createdAttribute.AttributeId }, createdAttribute);
        }
        #endregion

    }
}
