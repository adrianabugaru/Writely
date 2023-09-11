using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Writely.Models;

namespace Writely.Controllers
{
    public class QuickNotesController : Controller
    {
        private readonly WritelyContext _context;

        public QuickNotesController(WritelyContext context)
        {
            _context = context;
        }

        // GET: QuickNotes
        public async Task<IActionResult> Index()
        {
              return _context.QuickNotes != null ? 
                          View(await _context.QuickNotes.ToListAsync()) :
                          Problem("Entity set 'WritelyContext.QuickNotes'  is null.");
        }

        // GET: QuickNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuickNotes == null)
            {
                return NotFound();
            }

            var quickNote = await _context.QuickNotes
                .FirstOrDefaultAsync(m => m.QuickNoteId == id);
            if (quickNote == null)
            {
                return NotFound();
            }

            return View(quickNote);
        }

        // GET: QuickNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuickNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuickNoteId,QuickNoteName")] QuickNote quickNote)
        {
            if (ModelState.IsValid)
            {
                quickNote.CreatedTime = DateTime.Now;
                _context.Add(quickNote);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Documents");
            }
            return View(quickNote);
        }

        // GET: QuickNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuickNotes == null)
            {
                return NotFound();
            }

            var quickNote = await _context.QuickNotes.FindAsync(id);
            if (quickNote == null)
            {
                return NotFound();
            }
            return View(quickNote);
        }

        // POST: QuickNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuickNoteId,QuickNoteName")] QuickNote quickNote)
        {
            if (id != quickNote.QuickNoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quickNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuickNoteExists(quickNote.QuickNoteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Documents"); 
            }
            return View(quickNote);
        }

        // GET: QuickNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuickNotes == null)
            {
                return NotFound();
            }

            var quickNote = await _context.QuickNotes
                .FirstOrDefaultAsync(m => m.QuickNoteId == id);
            if (quickNote == null)
            {
                return NotFound();
            }

            return View(quickNote);
        }

        // POST: QuickNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuickNotes == null)
            {
                return Problem("Entity set 'WritelyContext.QuickNotes'  is null.");
            }
            var quickNote = await _context.QuickNotes.FindAsync(id);
            if (quickNote != null)
            {
                _context.QuickNotes.Remove(quickNote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Documents");
        }

        private bool QuickNoteExists(int id)
        {
          return (_context.QuickNotes?.Any(e => e.QuickNoteId == id)).GetValueOrDefault();
        }
    }
}
