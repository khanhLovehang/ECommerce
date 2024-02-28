using ECommerce.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Manager;
using Shared.DataTransferObjects.ReviewDto;
using Shared.RequestFeatures;
using System.Text.Json;

namespace ECommerce.Presentation.Controllers
{
    [Route("/api/products/{productId}/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        #region properties
        private readonly IServiceManager _service;
        #endregion

        #region constructor
        public ReviewController(IServiceManager service)
        {
            _service = service;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get list review
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReviewsForProduct(Guid productId, [FromQuery] ReviewParameters reviewParameters)
        {
            //var Reviews = await _service.ReviewService.GetReviewsAsync(productId, reviewParameters, trackChanges: false);
            var pagedResult = await _service.ReviewService.GetReviewsAsync(productId, reviewParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.reviews);
        }

        /// <summary>
        /// Get detail review
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetReviewForProduct")]
        public async Task<IActionResult> GetReview(Guid productId, int id)
        {
            var review = await _service.ReviewService.GetReviewAsync(productId, id, trackChanges: false);

            return Ok(review);
        }

        /// <summary>
        /// Create review value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateReviewForProduct(Guid productId, [FromBody] ReviewForCreationDto review)
        {
            var reviewReturn = await _service.ReviewService.CreateReviewForProductAsync(productId, review, trackChanges: false);

            return CreatedAtRoute("GetReviewForProduct", new { productId, id = reviewReturn.ReviewId }, reviewReturn);
        }

        /// <summary>
        /// Delete review value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReviewForProduct(Guid productId, int id)
        {
            await _service.ReviewService.DeleteReviewForProduct(productId, id, trackChanges: false);

            return NoContent();
        }

        /// <summary>
        /// Update review value for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="Review"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateReviewForProduct(Guid productId, int id, [FromBody] ReviewForUpdateDto review)
        {
            await _service.ReviewService.UpdateReviewForProduct(productId, id, review, proTrackChanges: false, revTrackChanges: true);

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
        public async Task<IActionResult> PartiallyUpdateReviewForProduct(Guid productId, int id, [FromBody] JsonPatchDocument<ReviewForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _service.ReviewService.GetReviewForPatch(productId, id, proTrackChanges: false, revTrackChanges: true);

            patchDoc.ApplyTo(result.reviewToPatch);

            await _service.ReviewService.SaveChangesForPatch(result.reviewToPatch, result.reviewEntity);

            return NoContent();
        }


        #endregion

    }
}
