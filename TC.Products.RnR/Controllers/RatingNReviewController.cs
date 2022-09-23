using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TC.Products.RnR.Manager.Models;
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
        [HttpGet("/api/RatingNReview/GetProductReviews/{productId}")]
        public IEnumerable<Reviews> GetProductReviews(int productId)
        {
            return _ratingService.GetReviewsByProductId(productId);
        }

        // GET 
        [HttpGet("/api/RatingNReview/GetProductRatingAndReviews/{productId}")]
        public ProductRatingReviews GetProductReviewsAndReviews(int productId)
        {
            return _ratingService.GetProductWithRatingAndReviews(productId);
        }

        // POST api/<RatingNReviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var review = JsonConvert.DeserializeObject<Reviews>(value);
            if (review != null)
            {


                string MailingListID = "7ff30dc9-ea2e-41ec-bad9-2476f3861417";
                string apiKey = "868563dd-a51f-412e-ab0d-b295ead11c6b";
                string postUrl = "https://api.moosend.com/v3/subscribers/{0}/subscribe.{1}?apikey={2}";
                string format = "json";
                var url = string.Format(postUrl, MailingListID, format, apiKey);
                using var client = new HttpClient();
                var newcontact = new { Age = "27", Name = "john123", Email = "validateval@mailinator.com", HasExternalDoubleOptIn = false, CustomFields = new List<string>() { "Country=US", "Rating=" + review.OverallRating + "" } };

                var jsonContactInfo = JsonConvert.SerializeObject(newcontact);
                var data = new StringContent(jsonContactInfo, Encoding.UTF8, "application/json");
                var response = client.PostAsync(url, data).Result;

                _ratingService.AddReview(review);
            }
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
            _ratingService.DeleteReview(id);
        }
    }
}
