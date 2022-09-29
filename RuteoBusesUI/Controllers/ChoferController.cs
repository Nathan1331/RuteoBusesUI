using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuteoBusesDAL;
using RuteoBusesUI.Conexion;
using System;

namespace RuteoBusesUI.Controllers
{
    public class ChoferController : Controller
    {
        #region Propiedad
        public GestorConexiones conexion { get; set; }
        #endregion

        #region Constructor 
        public ChoferController()
        {
            conexion = new GestorConexiones();
        }

        #endregion
        // GET: ChoferController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Chofer> Lista = await conexion.ListarChoferes();
            return View(Lista);
        }

        // GET: ChoferController/Details/5
        public ActionResult Details(int id)
        {
            var chofer = conexion.ChoferPorId(id).Result;
            if (chofer == null)
            {
                return NotFound();
            }
            return View(chofer);
        }

        // GET: ChoferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChoferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chofer? chofer)
        {
            try
            {
                conexion.AgregarChofer(chofer);
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
            var chofer = conexion.ChoferPorId(id).Result;
            if (chofer == null)
            {
                return NotFound();
            }
            return View(chofer);
        }

        // POST: ChoferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chofer chofer)
        {
            try
            {
                conexion.ModificarChofer(chofer.choferId, chofer);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(chofer);
            }
        }

        // GET: ChoferController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var chofer = conexion.ChoferPorId(id).Result;
            if (chofer == null)
            {
                return NotFound();
            }
            return View(chofer);
        }

        // POST: ChoferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? choferId)
        {
            try
            {
                conexion.EliminarChofer(choferId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
