using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TC.Products.RnR.Repository.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }
    }
}
