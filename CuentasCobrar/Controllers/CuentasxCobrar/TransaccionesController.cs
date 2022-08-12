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
    public class TransaccionesController : Controller
    {
        private readonly DbContext _context;

        public TransaccionesController(DbContext context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transacciones.ToListAsync());
        }

        // GET: Transacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacciones = await _context.Transacciones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transacciones == null)
            {
                return NotFound();
            }

            return View(transacciones);
        }

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            //Estado
            List<string> empleados = new List<string>();
            var vd = from em in _context.Estado select em;
            foreach (var item in vd)
            {
                empleados.Add(item.Descripcion);
                ViewBag.Estado = empleados;
            }
            //

            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Identificador_Transacción,Tipo_de_Movimiento,Tipo_Documento,Número_de_Documento,Fecha,Identificador_Cliente,Monto,Estado")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacciones = await _context.Transacciones.FindAsync(id);
            if (transacciones == null)
            {
                return NotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Identificador_Transacción,Tipo_de_Movimiento,Tipo_Documento,Número_de_Documento,Fecha,Identificador_Cliente,Monto,Estado")] Transacciones transacciones)
        {
            if (id != transacciones.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionesExists(transacciones.ID))
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
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacciones = await _context.Transacciones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (transacciones == null)
            {
                return NotFound();
            }

            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transacciones = await _context.Transacciones.FindAsync(id);
            _context.Transacciones.Remove(transacciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionesExists(int id)
        {
            return _context.Transacciones.Any(e => e.ID == id);
        }
    }
}
