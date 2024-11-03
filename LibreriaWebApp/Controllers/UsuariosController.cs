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
                return RedirectToAction("Login", new { mensaje = "Te registraste con éxito." });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string pass)
        {
            try
            {
                sistema.Login(email, pass);
                HttpContext.Session.SetString("email", email);
                return RedirectToAction("Index", "Publicaciones");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult CargarSaldo()
        {
            return View();
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
