using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace MVC_tuincentrum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var constraintsresolver = new DefaultInlineConstraintResolver();
            constraintsresolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
            routes.MapMvcAttributeRoutes(constraintsresolver);
            //routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                "Alleplanten",
                "Plantenlijst",
                new { Controller = "Plant", Action = "Index" });
            routes.MapRoute(
                "PlantByNr",
                "Plant/{id}",
                new { Controller = "Plant", Action = "Details" },
                new { id=new IntRouteConstraint()});
            routes.MapRoute(
                "PlantenVanEensoort",
                "soort/{soortnaam}/planten",
                new { Controller = "Plant", Action = "FindPlantenBySoortNaam" });
            routes.MapRoute(
                "PlantenVanEenLeverancier",
                "leverancier/{levnr}/planten",
                new { Controller = "Plant", Action = "FindPlantenByLeverancier" },
                new { levnr=new MaxRouteConstraint(10)});
            routes.MapRoute(
                "FindPlantenByPrijsBetween",
                "Planten",
                new { Controller = "Plant", Action = "FindPlantenBetweenPrijzen" },
                new { QueryConstraint = new QuerryStringConstraint(new string[] { "minprijs", "maxprijs" })});
            routes.MapRoute(
                "FindPlantenByKleur",
                "Planten",
                new { Controller = "Plant", action = "FindPlantenByKleur" },
                new { QueryConstraint = new QuerryStringConstraint(new string[] { "kleur" }) });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
