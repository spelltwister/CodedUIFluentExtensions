using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodedUIExamples
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "CodedUIPageModeling",
				url: "PageModeling/CodedUI",
				defaults: new {controller = "Home", action = "CodedUIPageModeling"}
			);

			routes.MapRoute(
				name: "HomeActions",
				url: "{action}",
				defaults: new {controller = "Home", action = "Index"}
			);

			routes.MapRoute(
				name: "ExampleActions",
				url: "Examples/{action}",
				defaults: new { controller = "Examples" }
			);

#if DEBUG
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
#endif
		}
	}
}