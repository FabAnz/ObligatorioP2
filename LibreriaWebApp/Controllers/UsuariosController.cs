using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApp.Controllers
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
            ViewBag.Exito = exito;
            ViewBag.Error = error;
            return View();
        }

        [HttpPost]
        public IActionResult LoginIngresar(string email, string pass)
        {
            try
            {
                sistema.Login(email, pass);
                HttpContext.Session.SetString("email", email);
                return RedirectToAction("Index", "Publicaciones");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", new { error = ex.Message });
            }
        }

        public IActionResult CargarSaldo()
        {
            try
            {
                Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));//Si el email es null manda la excepcion
                usuarioActivo.VerificarRol(Rol.Cliente);//Verifica que el rol sea el correcto para la accion

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CargarSaldo(int monto)
        {
            try
            {
                ViewBag.Exito = $"Se agregó $ {monto} a su saldo.";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
