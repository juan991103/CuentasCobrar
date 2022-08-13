using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuentasCobrar.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CuentasCobrar.Controllers.CuentasxCobrar
{
    public class AsientosContablesController : Controller
    {
        private readonly DbContext _context;
        private HttpClient httpClient = new HttpClient();

        public AsientosContablesController(DbContext context)
        {
            _context = context;
        }

        // GET: AsientosContables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asientos_Contables.ToListAsync());
        }

        // GET: AsientosContables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientos_Contables = await _context.Asientos_Contables
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asientos_Contables == null)
            {
                return NotFound();
            }

            return View(asientos_Contables);
        }

        // GET: AsientosContables/Create
        public IActionResult Create()
        {
            //Estado
            ViewBag.Estado = new SelectList(_context.Estado.ToList(), "Descripcion", "Descripcion");

            //Identificador del cliente
            ViewBag.IdenCliente = new SelectList(_context.Clientes.Where(f => f.Estado == "Activo").ToList(), "Identificador", "Identificador");

            return View();
        }

        // POST: AsientosContables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Identificador_Asiento,Descripcion,Identificador_Cliente,Cuenta,Tipo_de_Movimiento,Fecha_Asiento,Monto_Asiento,Estado")] Asientos_Contables asientos_Contables)
        {
            if (ModelState.IsValid)
            {
                ////llamar api de contabilidad
                var response = await callAccouningService(asientos_Contables);

                //////sacar id del response
                var responseAsString = await response.Content.ReadAsStringAsync();
                var accountingResponse = JsonConvert.DeserializeObject<AccountingResponse>(responseAsString);

                ////agergar id de contabilidad
                asientos_Contables.Id_registro = accountingResponse.responseList.ElementAt(0).id;

                //guardar BBDD local
                _context.Add(asientos_Contables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asientos_Contables);
        }

        public async Task<HttpResponseMessage> callAccouningService(Asientos_Contables asientos_Contables)
        {
            //map to request model
            var requestModel = mapToRequest(asientos_Contables);
            List<AccountingRequest> requestList = new List<AccountingRequest>();
            requestList.Add(requestModel);

            //call api
            var json = JsonConvert.SerializeObject(requestList);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Add("token", "cuenxc005");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync("https://service-accounting.herokuapp.com/api/AccountingEntry/", stringContent);

            return response;
        }


        public AccountingRequest mapToRequest(Asientos_Contables asientos_Contables)
        {

            //model request body
            AccountingRequest accountingRequest = new AccountingRequest();
            accountingRequest.Currency = "DOP";
            accountingRequest.Period = "2022-08";

            //details DB entry
            AccountingRequestDetails dbEntry = new AccountingRequestDetails
            {
                Amount = asientos_Contables.Monto_Asiento ?? 0,
                LegerAccount = 8,
                MovementType = "DB"
            };

            //details cr entry
            AccountingRequestDetails crEntry = new AccountingRequestDetails
            {
                Amount = asientos_Contables.Monto_Asiento ?? 0,
                LegerAccount = 11,
                MovementType = "CR"
            };

            List<AccountingRequestDetails> details = new List<AccountingRequestDetails>();
            details.Add(dbEntry);
            details.Add(crEntry);

            accountingRequest.Detail = details;

            return accountingRequest;

        }



        // GET: AsientosContables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientos_Contables = await _context.Asientos_Contables.FindAsync(id);
            if (asientos_Contables == null)
            {
                return NotFound();
            }
            return View(asientos_Contables);
        }

        // POST: AsientosContables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Identificador_Asiento,Descripcion,Identificador_Cliente,Cuenta,Tipo_de_Movimiento,Fecha_Asiento,Monto_Asiento,Estado")] Asientos_Contables asientos_Contables)
        {
            if (id != asientos_Contables.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asientos_Contables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Asientos_ContablesExists(asientos_Contables.ID))
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
            return View(asientos_Contables);
        }

        // GET: AsientosContables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asientos_Contables = await _context.Asientos_Contables
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asientos_Contables == null)
            {
                return NotFound();
            }

            return View(asientos_Contables);
        }

        // POST: AsientosContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asientos_Contables = await _context.Asientos_Contables.FindAsync(id);
            _context.Asientos_Contables.Remove(asientos_Contables);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Asientos_ContablesExists(int id)
        {
            return _context.Asientos_Contables.Any(e => e.ID == id);
        }
    }
}
