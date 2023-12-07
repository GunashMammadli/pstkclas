using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Areas.Admin.ViewModels.CategoryVM
{
    public class CategoryUpdateVM
    {
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
