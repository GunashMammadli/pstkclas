using Microsoft.EntityFrameworkCore;
using PustokMVC.Models;

namespace PustokMVC.Context
{
    public class PustokDbContext : DbContext
    {
        public PustokDbContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}
