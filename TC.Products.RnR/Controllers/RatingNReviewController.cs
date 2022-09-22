using Microsoft.AspNetCore.Mvc;
using TC.Products.RnR.Manager.Services;
using TC.Products.RnR.Repository.Models;
using TC.Products.RnR.Repository.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TC.Products.RnR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingNReviewController : ControllerBase
    {
        private readonly RatingService _ratingService;

        private readonly IRatingRepository _rating;

        public RatingNReviewController(IRatingRepository ratingRepository, RatingService ratingService)
        {
            _ratingService = ratingService;
            _rating = ratingRepository;
        }
        // GET: api/<RatingNReviewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RatingNReviewController>/5
        [HttpGet("{productId}")]
        public ProductRating GetProductRating(int productId)
        {
            return _ratingService.GetProductRatingByProductId(productId);
        }

        // GET 
        [HttpGet("/reviews/{productId}")]
        public IEnumerable<Reviews> GetProductReviews(int productId)
        {
            return _ratingService.GetReviewsByProductId(productId);
        }

        // POST api/<RatingNReviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RatingNReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RatingNReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
