using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Areas.Admin.ViewModels.BlogVM
{
    public class AuthorUpdateVM
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
