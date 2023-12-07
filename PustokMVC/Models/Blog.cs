using Microsoft.Build.Framework;

namespace PustokMVC.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
