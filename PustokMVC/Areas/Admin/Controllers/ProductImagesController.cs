using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Areas.Admin.ViewModels.ProductImagesVM;
using PustokMVC.Context;
using PustokMVC.Helpers;
using PustokMVC.Models;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImagesController : Controller
    {
        PustokDbContext _db { get; }
        IWebHostEnvironment _env { get; }

        public ProductImagesController(PustokDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.ProductImages.Select(s=> new AdminProductImagesListItemVM
            {
                Id = s.Id,
                ImagePath = s.ImagePath
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            ViewBag.Products = _db.Products;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductImageCreateVM vm)
        {
            ViewBag.Products = _db.Products;
            //if (!vm.ImagePath.IsCorrectType())
            //{
            //    ModelState.AddModelError("ImagePath", "Wrong file type");
            //}
            //if (!vm.ImagePath.IsValidSize())
            //{
            //    ModelState.AddModelError("ImagePath", "Files length must be less than kb");
            //}
            if (!ModelState.IsValid)  return View(vm); 
            ProductImages pi = new ProductImages
            {
                ProductId = vm.ProductId,
                ImagePath = await vm.ImageFile.SaveAsync(PathConstants.ProductImages)
            };
            await _db.ProductImages.AddAsync(pi);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.ProductImages.FindAsync(id);
            if (data == null) return NotFound();
            _db.ProductImages.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest(); 
            var data = await _db.ProductImages.FindAsync(id);
            if (data == null) return NotFound();
            ProductsImagesUpdateVM vm = new ProductsImagesUpdateVM
            {
                ImagePath = data.ImagePath,
            };
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,  ProductsImagesUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.ProductImages.FindAsync(id);
            if (data == null) return NotFound();
            data.ImagePath = vm.ImagePath;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
