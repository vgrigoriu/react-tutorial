using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Comments
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureFileServer(app);
            ConfigureWebApi(app);
        }

        private void ConfigureFileServer(IAppBuilder app)
        {
            var options = new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem("../../../public/"),
            };

            app.UseFileServer(options);
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            ConfigureWebApiRoutes(config);
            ConfigureJsonFormatter(config);

            app.UseWebApi(config);
        }

        private void ConfigureWebApiRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "comments.json",
                defaults: new { controller = "Comments" });
        }

        private void ConfigureJsonFormatter(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;

            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
