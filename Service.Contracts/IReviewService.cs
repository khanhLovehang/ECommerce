using Entities.Models;
using Shared.DataTransferObjects.ReviewDto;
using Shared.RequestFeatures;


namespace Service.Contracts
{
    public interface IReviewService
    {
        Task<(IEnumerable<ReviewDto> reviews, MetaData metaData)> GetReviewsAsync(Guid productId, ReviewParameters reviewParameters, bool trackChanges);
        Task<ReviewDto> GetReviewAsync(Guid productId, int id, bool trackChanges);
        Task<ReviewDto> CreateReviewForProductAsync(Guid productId, ReviewForCreationDto review, bool trackChanges);
        Task DeleteReviewForProduct(Guid productId, int id, bool trackChanges);
        Task UpdateReviewForProduct(Guid productId, int id
            , ReviewForUpdateDto ReviewForUpdate, bool proTrackChanges, bool revTrackChanges);
        Task<(ReviewForUpdateDto reviewToPatch, Review reviewEntity)> GetReviewForPatch(Guid productId, int id, bool proTrackChanges, bool revTrackChanges);
        Task SaveChangesForPatch(ReviewForUpdateDto reviewToPatch, Review reviewEntity);
    }
}
