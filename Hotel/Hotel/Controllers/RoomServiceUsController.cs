using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Repository;

namespace Hotel.Controllers
{
    public class RoomServiceUsController : Controller
    {
        private readonly HotelContext _context;

        public RoomServiceUsController(HotelContext context)
        {
            _context = context;
        }

        // GET: RoomServiceUs
        public async Task<IActionResult> Index()
        {
              return _context.RoomServiceU != null ? 
                          View(await _context.RoomServiceU.ToListAsync()) :
                          Problem("Entity set 'HotelContext.RoomServiceU'  is null.");
        }

        // GET: RoomServiceUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomServiceU == null)
            {
                return NotFound();
            }

            var roomServiceU = await _context.RoomServiceU
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceU == null)
            {
                return NotFound();
            }

            return View(roomServiceU);
        }

        // GET: RoomServiceUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomServiceUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomId,RoomDescription,RoomPrice,checkout")] RoomServiceU roomServiceU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomServiceU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomServiceU);
        }

        // GET: RoomServiceUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomServiceU == null)
            {
                return NotFound();
            }

            var roomServiceU = await _context.RoomServiceU.FindAsync(id);
            if (roomServiceU == null)
            {
                return NotFound();
            }
            return View(roomServiceU);
        }

        // POST: RoomServiceUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomId,RoomDescription,RoomPrice,checkout")] RoomServiceU roomServiceU)
        {
            if (id != roomServiceU.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomServiceU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceUExists(roomServiceU.Id))
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
            return View(roomServiceU);
        }

        // GET: RoomServiceUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomServiceU == null)
            {
                return NotFound();
            }

            var roomServiceU = await _context.RoomServiceU
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomServiceU == null)
            {
                return NotFound();
            }

            return View(roomServiceU);
        }

        // POST: RoomServiceUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomServiceU == null)
            {
                return Problem("Entity set 'HotelContext.RoomServiceU'  is null.");
            }
            var roomServiceU = await _context.RoomServiceU.FindAsync(id);
            if (roomServiceU != null)
            {
                _context.RoomServiceU.Remove(roomServiceU);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServiceUExists(int id)
        {
          return (_context.RoomServiceU?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
