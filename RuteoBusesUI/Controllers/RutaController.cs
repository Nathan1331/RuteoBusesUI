using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuteoBusesDAL;
using RuteoBusesUI.Conexion;
using System;

namespace RuteoBusesUI.Controllers
{
    public class RutaController : Controller
    {
        #region Propiedad
        public GestorConexiones conexion { get; set; }
        #endregion

        #region Constructor 
        public RutaController()
        {
            conexion = new GestorConexiones();
        }

        #endregion
        // GET: ChoferController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Ruta> Lista = await conexion.ListarRutas();
            return View(Lista);
        }

        // GET: ChoferController/Details/5
        public ActionResult Details(int id)
        {
            var ruta = conexion.RutaPorId(id).Result;
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // GET: ChoferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChoferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ruta? ruta)
        {
            try
            {
                conexion.AgregarRuta(ruta);
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
            var ruta = conexion.RutaPorId(id).Result;
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // POST: ChoferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ruta ruta)
        {
            try
            {
                conexion.ModificarRuta(ruta.rutaId, ruta);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(ruta);
            }
        }

        // GET: ChoferController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ruta = conexion.RutaPorId(id).Result;
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // POST: ChoferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? rutaId)
        {
            try
            {
                conexion.EliminarRuta(rutaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
