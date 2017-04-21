using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArtProjectService {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
					name: "Default",
					url: "{controller}/{action}/{id}",
					defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                    );

            routes.MapRoute(
                    name: "Cart",
                    url: "{controller}/{action}/{name}/{qty}",
                    defaults: new { controller = "api", action = "cart", id = UrlParameter.Optional }
                    );

            routes.MapRoute(
                    name: "Product",
                    url: "{controller}/{action}/{name}/{unit_price}/{special_qty}/{special_price}",
                    defaults: new { controller = "api", action = "product", id = UrlParameter.Optional }
                    );

        }
	}
}
