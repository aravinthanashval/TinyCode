using TC.Products.RnR.Repository.Models;
using TC.Products.RnR.Repository.Repository;

namespace TC.Products.RnR.Manager.Services
{
    public class RatingService
    {
        private readonly IRatingRepository _rating;

        public RatingService(IRatingRepository rating)
        {
            _rating = rating;
        }

        public ProductRating GetProductRatingByProductId(int productId)
        {
            return _rating.GetProductRatingByProductId(productId);
        }

        public IEnumerable<Reviews> GetReviewsByProductId(int productId)
        {
            return _rating.GetReviewsByProductId(productId);
        }

        public async Task<Reviews> AddReview(Reviews review)
        {
            return await _rating.AddReview(review);
        }

        public void DeleteReview(int reviewId)
        {
            _rating.DeleteReview(reviewId);
        }
    }
}
