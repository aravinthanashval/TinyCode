using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TC.Products.RnR.Repository.Models
{
    [Table("Reviews")]
    public class Reviews
    {
		[Key]
        public int ReviewId { get; set; }

        public int ProductId { get; set; }

        public int OverallRating { get; set; }

        public int Parameter1Rating { get; set; }

        public int Parameter2Rating { get; set; }

        public string? Review { get; set; }

        public string? UserId { get; set; }
	}
}
