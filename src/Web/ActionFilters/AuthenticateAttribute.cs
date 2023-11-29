using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.ActionFilters
{
    public class AuthenticateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // eğer user authenticate olmuşsa ve sunucuyu kapatıp tekrar girmek isterse logout olmasını ve login sayfasına gitmeyi sağlayan filtre ??? çerezlerden de silinebilir ??
            if (!context.HttpContext.User.Identity.IsAuthenticated &&
            context.ActionDescriptor.RouteValues["controller"].ToString().ToLower() == "home" &&
            context.ActionDescriptor.RouteValues["action"].ToString().ToLower() == "index") 
            {
                context.Result = new RedirectToActionResult("Logout", "Account", null);
            }
        }
    }

}
