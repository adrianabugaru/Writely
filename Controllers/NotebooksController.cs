﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Writely.Models;

namespace Writely.Controllers
{
    public class NotebooksController : Controller
    {
        private readonly WritelyContext _context;

        public NotebooksController(WritelyContext context)
        {
            _context = context;
        }

        // GET: Notebooks
        public async Task<IActionResult> Index()
        {
              return _context.Notebooks != null ? 
                          View(await _context.Notebooks.ToListAsync()) :
                          Problem("Entity set 'WritelyContext.Notebooks'  is null.");
        }

        // GET: Notebooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notebooks == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks
                .FirstOrDefaultAsync(m => m.NotebookId == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // GET: Notebooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotebookId,NotebookName")] Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notebook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notebook);
        }

        // GET: Notebooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notebooks == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }
            return View(notebook);
        }

        // POST: Notebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotebookId,NotebookName")] Notebook notebook)
        {
            if (id != notebook.NotebookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotebookExists(notebook.NotebookId))
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
            return View(notebook);
        }

        // GET: Notebooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notebooks == null)
            {
                return NotFound();
            }

            var notebook = await _context.Notebooks
                .FirstOrDefaultAsync(m => m.NotebookId == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // POST: Notebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notebooks == null)
            {
                return Problem("Entity set 'WritelyContext.Notebooks'  is null.");
            }
            var notebook = await _context.Notebooks.FindAsync(id);
            if (notebook != null)
            {
                _context.Notebooks.Remove(notebook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotebookExists(int id)
        {
          return (_context.Notebooks?.Any(e => e.NotebookId == id)).GetValueOrDefault();
        }
    }
}
