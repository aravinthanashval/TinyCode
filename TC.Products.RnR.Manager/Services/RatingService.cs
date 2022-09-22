using TC.Products.RnR.Manager.Models;
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

        public ProductRatingReviews GetProductWithRatingAndReviews(int productId)
        {
            var result = new ProductRatingReviews();
            result.ProductReviews = _rating.GetReviewsByProductId(productId);
            result.ProductRating = _rating.GetCalculatedProductRatingByProductId(productId);

            return result;
        }

        public Reviews AddReview(Reviews review)
        {
            return _rating.AddReview(review);
        }

        public void DeleteReview(int reviewId)
        {
            _rating.DeleteReview(reviewId);
        }
    }
}
