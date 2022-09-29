using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuteoBusesDAL;
using RuteoBusesUI.Conexion;
using System;

namespace RuteoBusesUI.Controllers
{
    public class UsuarioController : Controller
    {
        #region Propiedad
        public GestorConexiones conexion { get; set; }
        #endregion

        #region Constructor 
        public UsuarioController()
        {
            conexion = new GestorConexiones();
        }

        #endregion
        // GET: ChoferController
        public async Task<IActionResult> Index()
        {
            IEnumerable<Usuario> Lista = await conexion.ListarUsuarios();
            return View(Lista);
        }

        // GET: ChoferController/Details/5
        public ActionResult Details(int id)
        {
            var usuario = conexion.UsuarioPorId(id).Result;
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: ChoferController/Create
        public ActionResult Create()
        {
            ViewBag.Roles = conexion.ListarRolesSelectItems();
            return View();
        }

        // POST: ChoferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario? usuario)
        {
            try
            {
                conexion.AgregarUsuario(usuario);
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
            var usuario = conexion.UsuarioPorId(id).Result;
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: ChoferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                conexion.ModificarUsuario(usuario.userId, usuario);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: ChoferController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var usuario = conexion.UsuarioPorId(id).Result;
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: ChoferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? userId)
        {
            try
            {
                conexion.EliminarUsuario(userId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
