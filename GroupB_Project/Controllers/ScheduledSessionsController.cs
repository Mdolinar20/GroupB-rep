using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupB_Project.Data;
using GroupB_Project.Models;

namespace GroupB_Project.Controllers
{
    public class ScheduledSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduledSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScheduledSessions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduledSessions.ToListAsync());
        }

        // GET: ScheduledSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledSession = await _context.ScheduledSessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduledSession == null)
            {
                return NotFound();
            }

            return View(scheduledSession);
        }

        // GET: ScheduledSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduledSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ScheduledDate,Subject")] ScheduledSession scheduledSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduledSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduledSession);
        }

        // GET: ScheduledSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledSession = await _context.ScheduledSessions.FindAsync(id);
            if (scheduledSession == null)
            {
                return NotFound();
            }
            return View(scheduledSession);
        }

        // POST: ScheduledSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ScheduledDate,Subject")] ScheduledSession scheduledSession)
        {
            if (id != scheduledSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduledSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduledSessionExists(scheduledSession.Id))
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
            return View(scheduledSession);
        }

        // GET: ScheduledSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledSession = await _context.ScheduledSessions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduledSession == null)
            {
                return NotFound();
            }

            return View(scheduledSession);
        }

        // POST: ScheduledSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduledSession = await _context.ScheduledSessions.FindAsync(id);
            _context.ScheduledSessions.Remove(scheduledSession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduledSessionExists(int id)
        {
            return _context.ScheduledSessions.Any(e => e.Id == id);
        }
    }
}
