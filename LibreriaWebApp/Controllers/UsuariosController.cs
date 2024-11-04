using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        private Usuario UsuarioActivo()
        {
            return sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));
        }
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
                //Verifica que el rol sea el correcto para la accion, ademas si el usuario es null manda excepcion
                this.UsuarioActivo().VerificarRol(Rol.Cliente);
                                
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
                Cliente unCliente = this.UsuarioActivo() as Cliente;
                unCliente.CargarSaldo(monto);
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
