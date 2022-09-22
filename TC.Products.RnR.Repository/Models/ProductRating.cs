using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TC.Products.RnR.Repository.Models
{
    [Table("ProductRating")]
    [Keyless]
    public class ProductRating
    {
        public int ProductId { get; set; }

        public int AverageOverallRating { get; set; }

        public int AverageParameter1Rating { get; set; }

        public int AverageParameter2Rating { get; set; }
    }
}
