using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Obligatorio.Filters
{
    public class ClienteFiltro : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (rol != "Cliente")
            {
                context.Result = new RedirectToActionResult("Login", "Usuarios", new { error = "No tiene permiso para acceder a esta sección." });
            }
            base.OnActionExecuting(context);
        }
    }
}
