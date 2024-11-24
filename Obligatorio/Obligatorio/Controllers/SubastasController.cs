using LogicaNegocio;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Obligatorio.Filters;

namespace Obligatorio.Controllers
{
    [LogueadoFiltro]
    [AdministradorFiltro]
    public class SubastasController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        public IActionResult Index(string exito, string error)
        {
            try
            {
                ViewBag.Exito = exito;
                ViewBag.Error = error;

                return View(sistema.ListarSubastas());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Usuarios", new { error = ex.Message });
            }
        }

        public IActionResult Cerrar(int id)
        {
            try
            {
                Publicacion unaPublicacion = sistema.ObtenerPublicacionPorId(id);

                if (unaPublicacion == null || unaPublicacion.Estado != EstadoPublicacion.Abierta)
                    throw new Exception("La publicación a la que intentó acceder no está disponible.");

                if (!(unaPublicacion is Subasta))
                    throw new Exception("Error en el tipo de dato.");

                Subasta unaSubasta = (Subasta)unaPublicacion;
                ViewBag.Articulos = unaSubasta.Articulos;
                ViewBag.Ofertas = unaSubasta.Ofertas;
                return View(unaSubasta);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CerrarFinalizar(int id)
        {
            Subasta unaSubasta = (Subasta)sistema.ObtenerPublicacionPorId(id);
            unaSubasta.CerrarPublicacion(HttpContext.Session.GetString("email"));
            return RedirectToAction("Index", new { exito = "Subasta cerrada con exito." });
        }
    }
}

