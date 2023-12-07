using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Areas.Admin.ViewModels.ProductVM;
using PustokMVC.Context;
using PustokMVC.Models;
using PustokMVC.ViewModels;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        PustokDbContext _db { get; }

        public ProductController(PustokDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.Products.Select(s => new AdminProductListItemVM
            {
                Description = s.Description,
                Id = s.Id,
                Price = s.Price,
                Title = s.Title,
                ProductCode = s.ProductCode,
                Category = s.Category,
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            ViewBag.Categories = _db.Categories;
            if (!ModelState.IsValid) { return View(vm); }
            if (await _db.Products.AnyAsync(x => x.ProductCode == vm.ProductCode))
            {
                ModelState.AddModelError("ProductCode", "Product already exist");
                return View(vm);
            }
            Product product = new Product
            {
                Description = vm.Description,
                Price = vm.Price,
                Title = vm.Title,
                ProductCode = vm.ProductCode,
            };
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null) return BadRequest();
            var data = await _db.Products.FindAsync(id);
            if (data == null) return NotFound();
            _db.Products.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Products.FindAsync(id);
            if (data == null) return NotFound();
            ProductUpdateVM vm = new ProductUpdateVM
            {
                Description = data.Description,
                Price = data.Price,
                Title = data.Title,
                ProductCode = data.ProductCode,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Products.FindAsync(id);
            if (data == null) return NotFound();
            data.Description = vm.Description;
            data.Price = vm.Price;
            data.Title = vm.Title;
            data.ProductCode = vm.ProductCode;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
