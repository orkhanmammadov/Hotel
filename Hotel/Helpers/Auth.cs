using Hotel.Data;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hotel.Helpers
{
    public class Auth : ActionFilterAttribute
    {
        private HotelContext context;
        public Auth()
        {
            context = new HotelContext();
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (HttpContext.Current.Request.Cookies["cookie"] == null)
            {
                filterContext.Result = new RedirectResult("/login");
                return;
            }

            string token = HttpContext.Current.Request.Cookies["cookie"].Value.ToString();
            User user = context.Users.FirstOrDefault(u => u.token == token);

            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "login" },
                    { "action", "Index" }
               });
            }


        }
    }
}