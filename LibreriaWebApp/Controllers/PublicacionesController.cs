﻿using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApp.Controllers
{
    public class PublicacionesController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult Index(string exito, string error)
        {
            try
            {
                Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));//Si el email es null manda la excepcion
                usuarioActivo.VerificarRol(Rol.Cliente);//Verifica que el rol sea el correcto para la accion

                ViewBag.Exito = exito;
                ViewBag.Error = error;

                return View(sistema.Publicaciones);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Usuarios", new { error = ex.Message });
            }
        }

        public IActionResult Comprar(int id)
        {
            try
            {
                Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));//Si el email es null manda la excepcion
                usuarioActivo.VerificarRol(Rol.Cliente);//Verifica que el rol sea el correcto para la accion

                Publicacion unaPublicacion = sistema.ObtenerPublicacionPorId(id);

                if (unaPublicacion == null || unaPublicacion.Estado != EstadoPublicacion.Abierta)
                    throw new Exception("La publicación a la que intentó acceder no está disponible.");

                if (!(unaPublicacion is Venta))
                    throw new Exception("Error en el tipo de dato.");

                Venta unaVenta = (Venta)unaPublicacion;
                ViewBag.Articulos = unaVenta.Articulos;
                return View(unaVenta);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { error = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult ComprarFinalizar(int id)
        {
            try
            {
                Venta venta = (Venta)sistema.ObtenerPublicacionPorId(id);
                venta.CerrarPublicacion(HttpContext.Session.GetString("email"));
                return RedirectToAction("Index", new { exito = "Compra realizada con exito." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { error = ex.Message });
            }
        }

        public IActionResult Ofertar(int id)
        {
            try
            {
                Usuario usuarioActivo = sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email"));//Si el email es null manda la excepcion
                usuarioActivo.VerificarRol(Rol.Cliente);//Verifica que el rol sea el correcto para la accion

                Publicacion unaPublicacion = sistema.ObtenerPublicacionPorId(id);
                if (!(unaPublicacion is Subasta))
                    throw new Exception("Error en el tipo de dato.");
                Subasta unaSubasta = (Subasta)unaPublicacion;
                ViewBag.Articulos = unaSubasta.Articulos;
                return View(unaSubasta);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { error = ex.Message });

            }
        }
        [HttpPost]
        public IActionResult Ofertar(int idSubasta, double monto)
        {
            try
            {
                Subasta unaSubasta = (Subasta)sistema.ObtenerPublicacionPorId(idSubasta);
                Oferta oferta = new Oferta((Cliente)sistema.ObtenerUsuarioPorEmail(HttpContext.Session.GetString("email")), monto);
                unaSubasta.AgregarOferta(oferta);
                ViewBag.Articulos = unaSubasta.Articulos;
                ViewBag.Exito = "Oferta realizada con exito.";
                return View(unaSubasta);
            }
            catch (Exception ex)
            {
                Subasta unaSubasta = (Subasta)sistema.ObtenerPublicacionPorId(idSubasta);
                ViewBag.Articulos = unaSubasta.Articulos;
                ViewBag.Error = ex.Message;
                return View(unaSubasta);
            }
        }
    }
}