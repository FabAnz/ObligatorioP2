using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApp.Controllers
{
    public class PublicacionesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index(string exito, string error)
        {
            ViewBag.Exito = exito;
            ViewBag.Error = error;

            return View(sistema.Publicaciones);
        }

        public IActionResult Comprar(int id)
        {
            try
            {
                Venta unaVenta = (Venta)sistema.ObtenerPublicacionPorId(id);
                ViewBag.Articulos = unaVenta.Articulos;
                return View(unaVenta);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Ofertar");
            }
        }
        [HttpPost]
        public IActionResult ComprarFinalizar(int id)
        {
            try
            {
                Venta venta = (Venta)sistema.ObtenerPublicacionPorId(id);
                venta.CerrarPublicacion();
                return RedirectToAction("Index", new { exito = "Compra realizada con exito." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { error = ex.Message });
            }
        }

        public IActionResult Ofertar(int id)
        {
            Subasta unaSubasta = (Subasta)sistema.ObtenerPublicacionPorId(id);
            //ViewBag.Articulos = unaSubasta.Articulos;
            return View(unaSubasta);
        }
    }
}
