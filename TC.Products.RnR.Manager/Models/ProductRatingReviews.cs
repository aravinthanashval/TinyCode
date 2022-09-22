using TC.Products.RnR.Repository.Models;

namespace TC.Products.RnR.Manager.Models
{
    public class ProductRatingReviews
    {
        public ProductRating ProductRating { get; set; }
        public IEnumerable<Reviews> ProductReviews { get; set; }
    }
}
