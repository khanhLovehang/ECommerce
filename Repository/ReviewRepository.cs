using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.RequestFeatures;

namespace Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        #region properties
        #endregion

        #region properties
        public ReviewRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        #endregion

        #region methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<PagedList<Review>> GetReviewsAsync(Guid productId, ReviewParameters reviewParameters, bool trackChanges)
        {
            //Filter + Search
            var reviews = await FindByCondition(i => i.ProductId.Equals(productId), trackChanges).ToListAsync();

            return PagedList<Review>.ToPagedList(reviews, reviewParameters.PageNumber, reviewParameters.PageSize);

        }

        public async Task<Review> GetReviewAsync(Guid productId, int id, bool trackChanges) =>
            await FindByCondition(i => i.ProductId.Equals(productId) && i.ReviewId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateReviewForProduct(Guid productId, Review review)
        {
            review.ProductId = productId;
            Create(review);
        }

        public void DeleteReview(Review review) => Delete(review);

        #endregion
    }
}
