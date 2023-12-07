using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public List<Product>? Products { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
