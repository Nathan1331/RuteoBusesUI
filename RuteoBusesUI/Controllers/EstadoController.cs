using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuteoBusesDAL;
using RuteoBusesUI.Conexion;
using System;
using System.Net.Http.Headers;


namespace RuteoBusesUI.Controllers
{
    public class EstadoController : Controller
    {
        
        #region Propiedad
        public GestorConexiones conexion { get; set; }
        #endregion

        #region Constructor 
        public EstadoController()
        {
            conexion = new GestorConexiones();
        }

        #endregion

        // GET: BusController
        public async Task<IActionResult> Index()
        
        {
            IEnumerable<Estado> Lista = await conexion.ListarEstados();
            return View(Lista);
        }

        // GET: BusController/Details/5
        public ActionResult Details(int id)
        {
            var bus = conexion.EstadoPorId(id).Result;
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // GET: BusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estado estado)
        {
            try
            {
                conexion.AgregarEstado(estado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bus = conexion.EstadoPorId(id).Result;
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Estado estado)
        {
            try
            {
                conexion.ModificarEstado(estado.EstadoId, estado);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(estado);
            }
        }

        // GET: BusController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estado bus = conexion.EstadoPorId(id).Result;
            if (bus == null) 
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost( int? busId)
        {
            try
            {
                conexion.EliminarEstado(busId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
