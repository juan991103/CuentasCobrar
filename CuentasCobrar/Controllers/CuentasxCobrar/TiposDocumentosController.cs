using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuentasCobrar.Models;

namespace CuentasCobrar.Controllers.CuentasxCobrar
{
    public class TiposDocumentosController : Controller
    {
        private readonly DbContext _context;

        public TiposDocumentosController(DbContext context)
        {
            _context = context;
        }

        // GET: TiposDocumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipos_documentos.ToListAsync());
        }

        // GET: TiposDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_documentos = await _context.Tipos_documentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipos_documentos == null)
            {
                return NotFound();
            }

            return View(tipos_documentos);
        }

        // GET: TiposDocumentos/Create
        public IActionResult Create()
        {
            ViewBag.Estado = new SelectList(_context.Estado.ToList(), "Descripcion", "Descripcion");

            return View();
        }

        // POST: TiposDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Identificador,Descripcion,Cuenta_contable,Estado")] Tipos_documentos tipos_documentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipos_documentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipos_documentos);
        }

        // GET: TiposDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_documentos = await _context.Tipos_documentos.FindAsync(id);
            if (tipos_documentos == null)
            {
                return NotFound();
            }
            return View(tipos_documentos);
        }

        // POST: TiposDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Identificador,Descripcion,Cuenta_contable,Estado")] Tipos_documentos tipos_documentos)
        {
            if (id != tipos_documentos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipos_documentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipos_documentosExists(tipos_documentos.ID))
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
            return View(tipos_documentos);
        }

        // GET: TiposDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_documentos = await _context.Tipos_documentos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipos_documentos == null)
            {
                return NotFound();
            }

            return View(tipos_documentos);
        }

        // POST: TiposDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos_documentos = await _context.Tipos_documentos.FindAsync(id);
            _context.Tipos_documentos.Remove(tipos_documentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipos_documentosExists(int id)
        {
            return _context.Tipos_documentos.Any(e => e.ID == id);
        }
    }
}
