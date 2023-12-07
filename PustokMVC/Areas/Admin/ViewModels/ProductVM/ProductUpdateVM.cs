using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokMVC.Areas.Admin.ViewModels.ProductVM
{
    public class ProductUpdateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }
        [Required]
        public string ProductCode { get; set; }
        public int CategoryId { get; set; }
    }
}
