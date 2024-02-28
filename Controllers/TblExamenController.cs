using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WsApiexamen.Models;

namespace WsApiexamen.Controllers
{
    public class TblExamenController : Controller
    {
        private readonly BdiExamenContext _context;

        public TblExamenController(BdiExamenContext context)
        {
            _context = context;
        }

        // GET: TblExamen
        public async Task<IActionResult> Index()
        {
              return _context.TblExamen != null ? 
                          View(await _context.TblExamen.ToListAsync()) :
                          Problem("Entity set 'BdiExamenContext.TblExamen'  is null.");
        }

        // GET: TblExamen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblExamen == null)
            {
                return NotFound();
            }

            var tblExaman = await _context.TblExamen
                .FirstOrDefaultAsync(m => m.IdExamen == id);
            if (tblExaman == null)
            {
                return NotFound();
            }

            return View(tblExaman);
        }

        // GET: TblExamen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblExamen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExamen,Nombre,Descripcion")] TblExaman tblExaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblExaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblExaman);
        }

        // GET: TblExamen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblExamen == null)
            {
                return NotFound();
            }

            var tblExaman = await _context.TblExamen.FindAsync(id);
            if (tblExaman == null)
            {
                return NotFound();
            }
            return View(tblExaman);
        }

        // POST: TblExamen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExamen,Nombre,Descripcion")] TblExaman tblExaman)
        {
            if (id != tblExaman.IdExamen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblExaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblExamanExists(tblExaman.IdExamen))
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
            return View(tblExaman);
        }

        // GET: TblExamen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblExamen == null)
            {
                return NotFound();
            }

            var tblExaman = await _context.TblExamen
                .FirstOrDefaultAsync(m => m.IdExamen == id);
            if (tblExaman == null)
            {
                return NotFound();
            }

            return View(tblExaman);
        }

        // POST: TblExamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblExamen == null)
            {
                return Problem("Entity set 'BdiExamenContext.TblExamen'  is null.");
            }
            var tblExaman = await _context.TblExamen.FindAsync(id);
            if (tblExaman != null)
            {
                _context.TblExamen.Remove(tblExaman);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblExamanExists(int id)
        {
          return (_context.TblExamen?.Any(e => e.IdExamen == id)).GetValueOrDefault();
        }
    }
}
