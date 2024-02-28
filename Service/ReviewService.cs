using AutoMapper;
using Entities.Models;
using Service.Contracts;
using Shared.RequestFeatures;
using Contracts.Manager;
using Entities.Exceptions.ProductExceptions;
using Shared.DataTransferObjects.ReviewDto;
using Entities.Exceptions.ReviewExceptions;

namespace Service
{
    internal sealed class ReviewService : IReviewService
    {
        #region properties

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public ReviewService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion

        #region methods

        /// <summary>
        /// Get review value
        /// </summary>
        /// <param name="ReviewId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ReviewNotFoundException"></exception>
        public async Task<(IEnumerable<ReviewDto> reviews, MetaData metaData)> GetReviewsAsync(Guid productId, ReviewParameters reviewParameters, bool trackChanges)
        {
            await CheckIfProductExists(productId, trackChanges);

            var reviewsValueWithMetaData = await _repository.Review.GetReviewsAsync(productId, reviewParameters, trackChanges);

            var reviewsValueDto = _mapper.Map<IEnumerable<ReviewDto>>(reviewsValueWithMetaData);

            return (reviews: reviewsValueDto, metaData: reviewsValueWithMetaData.MetaData);
        }

        public async Task<ReviewDto> GetReviewAsync(Guid productId, int id, bool trackChanges)
        {
            await CheckIfProductExists(productId, trackChanges);

            var reviewFromDb = GetReviewForProductAndCheckIfItExists(productId, id, trackChanges);

            var review = _mapper.Map<ReviewDto>(reviewFromDb);

            return review;
        }

        /// <summary>
        /// Add value for review and product
        /// </summary>
        /// <param name="Review"></param>
        /// <returns></returns>
        public async Task<ReviewDto> CreateReviewForProductAsync(Guid productId, ReviewForCreationDto reviewForCreation, bool trackChanges)
        {
            await CheckIfProductExists(productId, trackChanges);

            var reviewEntity = _mapper.Map<Review>(reviewForCreation);

            _repository.Review.CreateReviewForProduct(productId, reviewEntity);

            await _repository.SaveAsync();

            var reviewToReturn = _mapper.Map<ReviewDto>(reviewEntity);

            return reviewToReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="ReviewNotFoundException"></exception>
        public async Task DeleteReviewForProduct(Guid productId, int id, bool trackChanges)
        {
            await CheckIfProductExists(productId, trackChanges);

            var reviewForProduct = await GetReviewForProductAndCheckIfItExists(productId, id, trackChanges);

            _repository.Review.DeleteReview(reviewForProduct);

            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="ReviewForUpdate"></param>
        /// <param name="proTrackChanges"></param>
        /// <param name="revTrackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="ReviewNotFoundException"></exception>
        public async Task UpdateReviewForProduct(Guid productId, int id
            , ReviewForUpdateDto reviewForUpdate, bool proTrackChanges, bool revTrackChanges)
        {
            await CheckIfProductExists(productId, proTrackChanges);

            var reviewEntity = await GetReviewForProductAndCheckIfItExists(productId, id, revTrackChanges);

            // We are mapping from the ReviewForUpdate object 
            // (we will change just the property in a request) to the
            // ReviewEntity — thus changing the state of the ReviewEntity
            // object to Modified.
            _mapper.Map(reviewForUpdate, reviewEntity);

            // Because our entity has a modified state, it is enough to call the SaveAsync
            // method without any additional update actions.
            await _repository.SaveAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="id"></param>
        /// <param name="proTrackChanges"></param>
        /// <param name="revTrackChanges"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        /// <exception cref="ReviewNotFoundException"></exception>
        public async Task<(ReviewForUpdateDto reviewToPatch, Review reviewEntity)> GetReviewForPatch(Guid productId, int id, bool proTrackChanges, bool revTrackChanges)
        {
            await CheckIfProductExists(productId, proTrackChanges);

            var reviewEntity = await GetReviewForProductAndCheckIfItExists(productId, id, revTrackChanges);

            var reviewToPatch = _mapper.Map<ReviewForUpdateDto>(reviewEntity);

            return (reviewToPatch, reviewEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ReviewToPatch"></param>
        /// <param name="ReviewEntity"></param>
        /// <returns></returns>
        public async Task SaveChangesForPatch(ReviewForUpdateDto reviewToPatch, Review reviewEntity)
        {
            _mapper.Map(reviewToPatch, reviewEntity);

            await _repository.SaveAsync();
        }

        #endregion

        #region private methods
        private async Task CheckIfProductExists(Guid productId, bool trackChanges)
        {
            var product = await _repository.Product.GetProductAsync(productId, trackChanges);
            if (product is null)
                throw new ProductNotFoundException(productId);
        }

        private async Task<Review> GetReviewForProductAndCheckIfItExists(Guid productId, int id, bool trackChanges)
        {
            var ReviewDb = await _repository.Review.GetReviewAsync(productId, id, trackChanges);
            if (ReviewDb is null)
                throw new ReviewNotFoundException(id);

            return ReviewDb;
        }

        #endregion
    }
}
