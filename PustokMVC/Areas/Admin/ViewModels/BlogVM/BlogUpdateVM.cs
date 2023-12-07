using PustokMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Areas.Admin.ViewModels.BlogVM
{
    public class BlogUpdateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Author Author { get; set; }
    }
}
