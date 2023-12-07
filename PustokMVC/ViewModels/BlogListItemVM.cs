using PustokMVC.Models;

namespace PustokMVC.ViewModels
{
    public class BlogListItemVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Author Author { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
