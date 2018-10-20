using Microsoft.Owin;
using Owin;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using AgileContentTestDomain.Services;
using AgileContentTestDomain.Interfaces;
using System.Web.Http;

[assembly: OwinStartup(typeof(AgileContentService.Startup))]
namespace AgileContentService
{
   
    public class Startup
    {
       public void Configuration(IAppBuilder app)
        {
            var filespath = ConfigurationManager.AppSettings["FilesPath"];

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CDNConverter>().As<ICDNConverter>().InstancePerRequest();

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

        }
    }
}
