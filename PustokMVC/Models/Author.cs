using System.ComponentModel.DataAnnotations;

namespace PustokMVC.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
