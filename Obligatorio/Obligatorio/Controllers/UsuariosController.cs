using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Filters;

namespace Obligatorio.Controllers
{
    public class UsuariosController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        
        public IActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarCliente(Cliente unCliente)
        {
            try
            {
                Sistema sistema = Sistema.Instancia;
                sistema.AgregarCliente(unCliente);
                return RedirectToAction("Login", new { exito = "Te registraste con éxito." });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Login(string exito, string error)
        {
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("nombre", "");
            HttpContext.Session.SetString("rol", "");
            ViewBag.Exito = exito;
            ViewBag.Error = error;
            return View();
        }

        [HttpPost]
        public IActionResult LoginIngresar(string email, string pass)
        {
            try
            {
                Sistema sistema = Sistema.Instancia;
                sistema.Login(email, pass);
                HttpContext.Session.SetString("email", email);
                Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));
                HttpContext.Session.SetString("nombre", usuarioActivo.Nombre);

                Rol unRol = usuarioActivo.ObtenerRol();
                HttpContext.Session.SetString("rol", unRol.ToString());

                if (unRol == Rol.Cliente)
                    return RedirectToAction("Index", "Publicaciones");
                return RedirectToAction("Index", "Subastas");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", new { error = ex.Message });
            }
        }

        [LogueadoFiltro]
        [ClienteFiltro]
        public IActionResult CargarSaldo()
        {
            try
            {
                Sistema sistema = Sistema.Instancia;
                Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));


                Cliente unCliente = usuarioActivo as Cliente;
                ViewBag.Saldo = unCliente.Saldo;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", new { error = ex.Message });
            }
        }

        [HttpPost]
        [ClienteFiltro]
        [LogueadoFiltro]
        public IActionResult CargarSaldo(int monto)
        {
            Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));
            try
            {
                Cliente unCliente = usuarioActivo as Cliente;
                unCliente.CargarSaldo(monto);
                ViewBag.Saldo = unCliente.Saldo;
                ViewBag.Exito = $"Se agregó $ {monto} a su saldo.";
                return View();
            }
            catch (Exception ex)
            {
                Cliente unCliente = usuarioActivo as Cliente;
                ViewBag.Saldo = unCliente.Saldo;
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
