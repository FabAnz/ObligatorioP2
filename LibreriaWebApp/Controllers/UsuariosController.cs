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
                ViewBag.Exito = "Te registraste con éxito.";
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
