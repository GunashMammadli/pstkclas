using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Areas.Admin.ViewModels.CategoryVM
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
