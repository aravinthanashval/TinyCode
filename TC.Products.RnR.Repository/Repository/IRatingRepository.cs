using TC.Products.RnR.Repository.Models;

namespace TC.Products.RnR.Repository.Repository
{
    public interface IRatingRepository
    {
        IEnumerable<Reviews> GetReviewsByProductId(int productId);

        ProductRating GetProductRatingByProductId(int productId);

        ProductRating GetCalculatedProductRatingByProductId(int productId);

        Reviews AddReview(Reviews review);

        void DeleteReview(int reviewId);
    }
}
