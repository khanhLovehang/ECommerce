using Entities.Exceptions.Base;

namespace Entities.Exceptions.ReviewExceptions
{
    public class ReviewNotFoundException : NotFoundException
    {
        public ReviewNotFoundException(int reviewId)
            : base($"Review value with id: {reviewId} doesn't exist in the database.")
        {

        }
    }
}
