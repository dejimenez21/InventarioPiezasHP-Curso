using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario_Computos.Models;

namespace Sistema_Inventario_Computos.Controllers
{
    public class TipoPiezasController : Controller
    {
        private readonly RegistroPiezasDBContext _context;

        public TipoPiezasController(RegistroPiezasDBContext context)
        {
            _context = context;
        }

        // GET: TipoPiezas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTipoPieza.ToListAsync());
        }

        // GET: TipoPiezas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoPieza = await _context.TblTipoPieza
                .FirstOrDefaultAsync(m => m.IdTipoPieza == id);
            if (tblTipoPieza == null)
            {
                return NotFound();
            }

            return View(tblTipoPieza);
        }

        // GET: TipoPiezas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPiezas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPieza,Descripcion")] TblTipoPieza tblTipoPieza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTipoPieza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTipoPieza);
        }

        // GET: TipoPiezas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoPieza = await _context.TblTipoPieza.FindAsync(id);
            if (tblTipoPieza == null)
            {
                return NotFound();
            }
            return View(tblTipoPieza);
        }

        // POST: TipoPiezas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPieza,Descripcion")] TblTipoPieza tblTipoPieza)
        {
            if (id != tblTipoPieza.IdTipoPieza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTipoPieza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTipoPiezaExists(tblTipoPieza.IdTipoPieza))
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
            return View(tblTipoPieza);
        }

        // GET: TipoPiezas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoPieza = await _context.TblTipoPieza
                .FirstOrDefaultAsync(m => m.IdTipoPieza == id);
            if (tblTipoPieza == null)
            {
                return NotFound();
            }

            return View(tblTipoPieza);
        }

        // POST: TipoPiezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTipoPieza = await _context.TblTipoPieza.FindAsync(id);
            _context.TblTipoPieza.Remove(tblTipoPieza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTipoPiezaExists(int id)
        {
            return _context.TblTipoPieza.Any(e => e.IdTipoPieza == id);
        }
    }
}
