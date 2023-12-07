using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Areas.Admin.ViewModels.SliderVM;
using PustokMVC.Context;
using PustokMVC.Models;
using PustokMVC.ViewModels;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        PustokDbContext _db { get; }

        public SliderController(PustokDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.Sliders.Select(s => new SliderListItemVM
            {
                BookName = s.BookName,
                ButtonText = s.ButtonText,
                Description = s.Description,
                Image = s.Image,
                Id = s.Id
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Slider slider = new Slider
            {
                BookName= vm.BookName,
                ButtonText= vm.ButtonText,
                Description = vm.Description,
                Image = vm.Image
            };
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            _db.Sliders.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            return View(new SliderUpdateVM
            {
                BookName = data.BookName,
                ButtonText= data.ButtonText,
                Description = data.Description,
                Image = data.Image
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM vm)
        {
            if (id == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            data.BookName = vm.BookName;
            data.ButtonText = vm.ButtonText;
            data.Description = vm.Description;
            data.Image = vm.Image;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
