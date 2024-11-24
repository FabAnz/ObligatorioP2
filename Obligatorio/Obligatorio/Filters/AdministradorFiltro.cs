using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Obligatorio.Filters
{
    public class AdministradorFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (rol != "Administrador")
            {
                context.Result = new RedirectToActionResult("Login", "Usuarios", new { error = "No tiene permiso para acceder a esta sección." });
            }
            base.OnActionExecuting(context);
        }
    }
}