using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Areas.Admin.ViewModels.BlogVM;
using PustokMVC.Context;
using PustokMVC.Models;
using PustokMVC.ViewModels;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        PustokDbContext _db { get; }

        public BlogController(PustokDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.Blogs.Select(s => new BlogListItemVM
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
                IsDeleted = s.IsDeleted
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            Blog blog = new Blog
            {
                Description = vm.Description,
                Title = vm.Title,
                CreatedAt = DateTime.Now,
            };
            await _db.Blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Blogs.FindAsync(id);
            if (data == null) return BadRequest();
            _db.Blogs.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            BlogUpdateVM vm = new BlogUpdateVM
            {
                Description = data.Description,
                Title = data.Title,
                UpdatedAt = DateTime.Now,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, BlogUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            data.Description = vm.Description;
            data.Title = vm.Title;
            data.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
