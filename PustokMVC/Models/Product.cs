using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public List<ProductImages>? ProductsImages { get; set;}
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool IsDeleted { get; set; }= false;
    }
}
