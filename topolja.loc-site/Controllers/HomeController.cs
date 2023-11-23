using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using topolja.loc_site.Data;
using topolja.loc_site.Models;

namespace topolja.loc_site.Controllers
{
    public class HomeController : Controller
    {
        private readonly FootballersDbContext _context;

        public HomeController(FootballersDbContext context)
        {
            _context = context;
        }

        public IActionResult Footballers()
        {
            var footballers = _context.Footballers
                        .Include(f => f.Team)
                        .ToList();

            return View(footballers);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _context.Teams.ToList();

            var footballer = _context.Footballers
                .Include(f => f.Team)
                .FirstOrDefault(f => f.Id == id);

            if (footballer == null)
            {
                return NotFound();
            }

            return View(footballer);
        }

        [HttpPost]
        public IActionResult Edit(Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(footballer);
                _context.SaveChanges();
                return RedirectToAction("Footballers");
            }

            return View(footballer);
        }

        public IActionResult Index()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Footballer footballer)
        {
            if (ModelState.IsValid)
            {
                _context.Footballers.Add(footballer);
                _context.SaveChanges();
                return RedirectToAction("Footballers");
            }

            ViewBag.Teams = _context.Teams.ToList();
            return View(footballer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
