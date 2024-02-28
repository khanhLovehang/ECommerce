using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReviewRepository
    {
        Task<PagedList<Review>> GetReviewsAsync(Guid productId, ReviewParameters reviewParameters, bool trackChanges);
        Task<Review> GetReviewAsync(Guid productId, int id, bool trackChanges);
        void CreateReviewForProduct(Guid productId, Review review);
        void DeleteReview(Review review);
    }
}
