using CLDV6211POEProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CLDV6211POEProject.Controllers
{
    public class Event1Controller : Controller
    {

        private readonly ApplicationDbContext _context;

        public Event1Controller(ApplicationDbContext context) 
        {
            _context = context;
        
        }

        public async Task<IActionResult> Index()
        {
            var event1 = await _context.Event1.ToListAsync();
            return View(event1);
        }

        public IActionResult Create() 
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event1 event2)
        {

            if (ModelState.IsValid)
            {

                _context.Add(event2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(event2);
        }

        public async Task<IActionResult> Details(int id)
        {
            var event2 = await _context.Event1.FirstOrDefaultAsync(m => m.Event_Id == id); 

            if (event2 == null)
            {

                return NotFound();
            }

            return View(event2);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var event2 = await _context.Event1.FirstOrDefaultAsync(m => m.Event_Id == id);

            if (event2 == null)
            {

                return NotFound();
            }

            return View(event2);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var event2 = await _context.Event1.FindAsync(id);
            _context.Event1.Remove(event2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool EventExist(int id)
        { 
        
        return _context.Event1.Any(e => e.Event_Id == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {

                return NotFound();
            }

            var event2 = await _context.Event1.FindAsync(id);

            if (id == null) 
            {
                return NotFound();
            }
            return View(event2);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event1 event2)
        {

            if (id != event2.Event_Id) 
            {

                return NotFound();
            }

            if (ModelState.IsValid) 
            {
                try
                {

                    _context.Update(event2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) 
                {

                    if (!EventExist(event2.Event_Id))
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
            return View(event2);
        }



    }
}
