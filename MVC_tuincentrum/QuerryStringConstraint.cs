using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC_tuincentrum
{
    public class QuerryStringConstraint : IRouteConstraint
    {
        private string[] verwachteParameters;
        public QuerryStringConstraint(string[] verwachteparameters)
        {
            this.verwachteParameters = verwachteparameters;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            foreach(string verwachteparameter in verwachteParameters)
            {
                if (!httpContext.Request.QueryString.AllKeys.Contains(verwachteparameter, StringComparer.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }
    }
}