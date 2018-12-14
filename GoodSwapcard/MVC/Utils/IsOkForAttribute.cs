using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Utils
{
    public class IsOkForAttribute : AuthorizeAttribute
    {
        private string[] _rolesAhth;
        public IsOkForAttribute(params string[] roles)
        {
            _rolesAhth = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (UserSession.CurrentUser == null || !_rolesAhth.Contains(UserSession.CurrentUser.statut.StatutName))
            {
                filterContext.Result = new RedirectToRouteResult(
                                        new RouteValueDictionary {
                                                                    { "action", "Index" },
                                                                    { "controler","Home"},
                                                                    { "Area", string.Empty}
                                                                });
            }
        }
    }
}