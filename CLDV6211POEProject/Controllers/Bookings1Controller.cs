using CLDV6211POEProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLDV6211POEProject.Controllers
{
    public class Bookings1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Bookings1Controller(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var booking = await _context.Bookings1.ToListAsync();
            return View(booking);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bookings1 booking)
        {

            if (ModelState.IsValid)
            {

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }

        public async Task<IActionResult> Details(int id)
        {
            var event2 = await _context.Bookings1.FirstOrDefaultAsync(m => m.Booking_Id == id);

            if (event2 == null)
            {

                return NotFound();
            }

            return View(event2);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var booking = await _context.Bookings1.FirstOrDefaultAsync(m => m.Booking_Id == id);

            if (booking == null)
            {

                return NotFound();
            }

            return View(booking);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.Bookings1.FindAsync(id);
            _context.Bookings1.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool EventExist(int id)
        {

            return _context.Bookings1.Any(e => e.Booking_Id == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {

                return NotFound();
            }

            var booking = await _context.Bookings1.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Bookings1 booking)
        {

            if (id != booking.Booking_Id)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!EventExist(booking.Booking_Id))
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
            return View(booking);
        }
    }
}
