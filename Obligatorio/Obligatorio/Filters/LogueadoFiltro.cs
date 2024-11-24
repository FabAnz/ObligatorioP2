using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Obligatorio.Filters
{
    public class LogueadoFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string logueado = context.HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(logueado))
            {
                context.Result = new RedirectToActionResult("Login", "Usuarios", new { error = "Debe iniciar sesion." });
            }
            base.OnActionExecuting(context);
        }
    }
}
