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

        public async Task<Reviews> AddReview(Reviews review)
        {
            var obj = await _appDBContext.Reviews.AddAsync(review);
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
