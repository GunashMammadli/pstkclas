﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Areas.Admin.ViewModels.CategoryVM;
using PustokMVC.Context;
using PustokMVC.Models;
using PustokMVC.ViewModels;

namespace PustokMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        PustokDbContext _db { get; }

        public CategoryController(PustokDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _db.Categories.Select(s=> new CategoryListItemVM
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId,
            }).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM vm)
        {
            if(!ModelState.IsValid) return View(vm);
            Category category = new Category
            {
                Name = vm.Name,
                CategoryId = vm.CategoryId,
            };
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Categories.FindAsync(id);
            if (data == null) return NotFound();
            _db.Categories.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _db.Categories.FindAsync(id);
            if (data == null) return NotFound();
            CategoryUpdateVM vm = new CategoryUpdateVM
            {
                Name = data.Name,
                CategoryId = data.CategoryId,
            };
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, CategoryUpdateVM vm)
        {
            if (id == null) return BadRequest();
            var data = await _db.Categories.FindAsync(id);
            if (data == null) return NotFound();
            data.CategoryId = vm.CategoryId;
            data.Name = vm.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
