using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMVC.Context;
using PustokMVC.Models;
using System.Diagnostics;

namespace PustokMVC.Controllers
{
    public class HomeController : Controller
    {
        PustokDbContext _context { get; }

        public HomeController(PustokDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }
    }
}
