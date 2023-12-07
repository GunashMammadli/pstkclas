using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Areas.Admin.ViewModels.BlogVM;
using PustokMVC.Context;
using PustokMVC.Models;
using PustokMVC.ViewModels;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        PustokDbContext _db { get; }

        public AuthorController(PustokDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.Author.Select(s => new AuthorListItemVM
            {
                 Id = s.Id,
                 Name = s.Name,
                 Surname = s.Surname
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View (vm);
            }
            Author author = new Author
            {
                Name = vm.Name,
                Surname = vm.Surname
            };
            await _db.Author.AddAsync(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Author.FindAsync(id);
            if (data == null) return NotFound();
            _db.Author.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update (int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Author.FindAsync(id);
            if (data == null) return NotFound();
            AuthorUpdateVM author = new AuthorUpdateVM
            {
                Name = data.Name,
                Surname = data.Surname,
            };
            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> Update (int? id,  AuthorUpdateVM vm)
        {
            if (id == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Author.FindAsync(id);
            if(data == null) return NotFound();
            data.Name = vm.Name;
            data.Surname = vm.Surname;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
