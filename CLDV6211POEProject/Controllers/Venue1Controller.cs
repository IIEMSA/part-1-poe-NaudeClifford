using CLDV6211POEProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLDV6211POEProject.Controllers
{
    public class Venue1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Venue1Controller(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var venue = await _context.Venue1.ToListAsync();
            return View(venue);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venue1 venue)
        {

            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(venue);
        }

        public async Task<IActionResult> Details(int id)
        {
            var event2 = await _context.Venue1.FirstOrDefaultAsync(m => m.Venue_Id == id);

            if (event2 == null)
            {

                return NotFound();
            }

            return View(event2);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var venue = await _context.Venue1.FirstOrDefaultAsync(m => m.Venue_Id == id);

            if (venue == null)
            {

                return NotFound();
            }

            return View(venue);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _context.Venue1.FindAsync(id);
            _context.Venue1.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool EventExist(int id)
        {

            return _context.Venue1.Any(e => e.Venue_Id == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {

                return NotFound();
            }

            var venue = await _context.Venue1.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Venue1 venue)
        {

            if (id != venue.Venue_Id)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!EventExist(venue.Venue_Id))
                    {

                        return NotFound();
                    }
                    else
                    {

                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }
    }
}
