using TC.Products.RnR.Repository.Models;
using TC.Products.RnR.Repository.Data;

namespace TC.Products.RnR.Repository.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _appDBContext;
        public RatingRepository(ApplicationDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public ProductRating GetProductRatingByProductId(int productId)
        {
            try
            {
                return _appDBContext.ProductRating.Where(x => x.ProductId == productId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ProductRating GetCalculatedProductRatingByProductId(int productId)
        {
            var count = _appDBContext.Reviews.Where(x => x.ProductId == productId).Count();

            var result = new ProductRating()
            {
                ProductId = productId
            };

            if (count > 0)
            {
                var avgrating = _appDBContext.Reviews.Where(x => x.ProductId == productId).Average(x => x.OverallRating);
                var p1rating = _appDBContext.Reviews.Where(x => x.ProductId == productId).Average(x => x.Parameter1Rating);
                var p2rating = _appDBContext.Reviews.Where(x => x.ProductId == productId).Average(x => x.Parameter2Rating);

                result.AverageOverallRating = (int)avgrating;
                result.AverageParameter1Rating = (int)p1rating;
                result.AverageParameter2Rating = (int)p2rating;
            }

            return result;
        }

        public IEnumerable<Reviews> GetReviewsByProductId(int productId)
        {
            try
            {
                return _appDBContext.Reviews.Where(x => x.ProductId == productId).ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public Reviews AddReview(Reviews review)
        {
            var obj = _appDBContext.Reviews.Add(review);
            _appDBContext.SaveChanges();
            return obj.Entity;
        }

        public void DeleteReview(int reviewId)
        {
            var review = _appDBContext.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            _appDBContext.Remove(review);
            _appDBContext.SaveChanges();
        }
    }
}
