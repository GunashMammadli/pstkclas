using PustokMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Areas.Admin.ViewModels.BlogVM
{
    public class BlogCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Author Author { get; set; }
    }
}
