using Microsoft.AspNetCore.Mvc;
using FrontEnd_Hotel.Data;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using RuteoBusesDAL;

namespace FrontEnd_Hotel.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {

            DA_logica da_usuario = new DA_logica();
            var usuario = da_usuario.ValidarUsuario(_usuario.Identificacion, _usuario.clave);

            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,usuario.nombre),
                    new Claim("",usuario.Identificacion)
                };

                if (usuario.rolId == 1)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("index","Home");
            }
            else
            {
                return View();
            }


        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }
        public async Task<IActionResult> Logout() 
        {
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,"")
                };

            claims.Add(new Claim(ClaimTypes.Role, "none"));
        

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("index","Home");
    }
    }
}
