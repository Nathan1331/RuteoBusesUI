using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuteoBusesDAL;
using RuteoBusesUI.Conexion;
using System;
using System.Net.Http.Headers;


namespace RuteoBusesUI.Controllers
{
    public class BusController : Controller
    {
        
        #region Propiedad
        public GestorConexiones conexion { get; set; }
        #endregion

        #region Constructor 
        public BusController()
        {
            conexion = new GestorConexiones();
        }

        #endregion

        // GET: BusController
        public async Task<IActionResult> Index()
        
        {
            IEnumerable<Bus> Lista = await conexion.ListarBuses();
            return View(Lista);
        }

        public async Task<IActionResult> BusesEstado(int id)

        {
            IEnumerable<Bus> Lista = await conexion.ListarBusesEstado(id);
            return View(Lista);
        }
        public async Task<IActionResult> BusesChofer(int id)

        {
            IEnumerable<Bus> Lista = await conexion.ListarBusesChofer(id);
            return View(Lista);
        }
        // GET: BusController/Details/5
        public ActionResult Details(int id)
        {
            var bus = conexion.BusPorId(id).Result;
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // GET: BusController/Create
        public ActionResult Create()
        {
            ViewBag.Estados = conexion.ListarEstadosSelectItems();
            ViewBag.Rutas = conexion.ListarRutasSelectItems();
            ViewBag.Choferes = conexion.ListarChoferesSelectItems();
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bus bus)
        {
            try
            {
                conexion.AgregarBus(bus);
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
            var bus = conexion.BusPorId(id).Result;
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bus bus)
        {
            try
            {
                conexion.ModificarBus(bus.busId, bus);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(bus);
            }
        }

        // GET: BusController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Bus bus = conexion.BusPorId(id).Result;
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
                conexion.EliminarBus(busId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
