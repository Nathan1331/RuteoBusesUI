using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuteoBusesDAL;
using RuteoBusesUI.Conexion;
using System;

namespace RuteoBusesUI.Controllers
{
    public class ParadaRutaController : Controller
    {
        #region Propiedad
        public GestorConexiones conexion { get; set; }
        #endregion

        #region Constructor 
        public ParadaRutaController()
        {
            conexion = new GestorConexiones();
        }

        #endregion
        // GET: ChoferController
        public async Task<IActionResult> Index()
        {
            IEnumerable<ParadaRuta> Lista = await conexion.ListarParadasRutas();
            return View(Lista);
        }

        // GET: ChoferController/Details/5
        public ActionResult Details(int id)
        {
            var paradaRuta = conexion.ParadaRutaPorId(id).Result;
            if (paradaRuta == null)
            {
                return NotFound();
            }
            return View(paradaRuta);
        }

        // GET: ChoferController/Create
        public ActionResult Create()
        {
            ViewBag.Buses = conexion.ListarBusesSelectItems();
            ViewBag.Rutas = conexion.ListarRutasSelectItems();
            return View();
        }

        // POST: ChoferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParadaRuta? paradaRuta)
        {
            try
            {
                conexion.AgregarParadaRuta(paradaRuta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChoferController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var paradaRuta = conexion.ParadaRutaPorId(id).Result;
            if (paradaRuta == null)
            {
                return NotFound();
            }
            return View(paradaRuta);
        }

        // POST: ChoferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParadaRuta paradaRuta)
        {
            try
            {
                conexion.ModificarParadaRuta(paradaRuta.paradaRutaId, paradaRuta);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(paradaRuta);
            }
        }

        // GET: ChoferController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var paradaRuta = conexion.ParadaRutaPorId(id).Result;
            if (paradaRuta == null)
            {
                return NotFound();
            }
            return View(paradaRuta);
        }

        // POST: ChoferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? paradaRutaId)
        {
            try
            {
                conexion.EliminarParadaRuta(paradaRutaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
