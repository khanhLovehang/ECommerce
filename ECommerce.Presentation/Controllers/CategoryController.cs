using Microsoft.AspNetCore.Mvc;
using Shared.RequestFeatures;
using ECommerce.Presentation.ModelBinders;
using ECommerce.Presentation.ActionFilters;
using Service.Contracts.Manager;
using Shared.DataTransferObjects.CategoryDto;

namespace ECommerce.Presentation.Controllers
{
    [Route("/api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region properties
        private readonly IServiceManager _service;
        #endregion

        #region constructor
        public CategoryController(IServiceManager service)
        {
            _service = service;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get all Categorys
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCategorys([FromQuery] CategoryParameters categoryParameters)
        {
            var categorys = await _service.CategoryService.GetAllCategorysAsync(categoryParameters, trackChanges: false);

            return Ok(categorys);
        }

        /// <summary>
        /// Get a Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _service.CategoryService.GetCategoryAsync(id, trackChanges: false);

            return Ok(category);
        }

        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.CategoryId }, createdCategory);
        }

        /// <summary>
        /// Get a collection of Category
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("collection/({ids})", Name = "CategoryCollection")]
        public async Task<IActionResult> GetCategoryCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var categories = await _service.CategoryService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(categories);
        }

        /// <summary>
        /// Create a collection of Category
        /// </summary>
        /// <param name="CategoryCollection"></param>
        /// <returns></returns>
        [HttpPost("collection")]
        public async Task<IActionResult> CreateCategoryCollection([FromBody] IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            var result = await _service.CategoryService.CreateCategoryCollection(categoryCollection);

            return CreatedAtRoute("CategoryCollection", new { result.ids }, result.categories);
        }

        /// <summary>
        /// Delete Category (and its attribute value)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
           await _service.CategoryService.DeleteCategoryAsync(id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Update Category (while insert child resource - attribute value)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryForUpdateDto category)
        {
            await _service.CategoryService.UpdateCategoryAsync(id, category, trackChanges: true);

            return NoContent();
        }


        #endregion

    }
}
