using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Araretama.BomNaEscolaBomDeBola.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public static void Register(HttpConfiguration config)
        {
            
        }
        protected void Application_BeginRequest()
        {
            // var cors = new EnableCorsAttribute("*", "*", "*");
            // config.EnableCors(cors);
            /*

               HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http:///localhost:8100");
               HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS,PUT,DELETE");
               HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");
               HttpContext.Current.Response.End();

  
            /*
                           if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                           {
                               HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS,PUT,DELETE");
                               HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");
                               HttpContext.Current.Response.End();
                           }

                  */

        }
    }
}
