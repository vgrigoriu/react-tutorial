using System;
using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Comments
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.ReadLine();
            }
        }
    }
}

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var options = new FileServerOptions()
        {
            FileSystem = new PhysicalFileSystem("../../../public/"),
        };

        app.UseFileServer(options);

        var config = new HttpConfiguration();
        config.Routes.MapHttpRoute(
            name: "Default",
            routeTemplate: "comments.json",
            defaults: new { controller = "Comments" });

        var formatters = config.Formatters;
        var jsonFormatter = formatters.JsonFormatter;
        var settings = jsonFormatter.SerializerSettings;
        settings.Formatting = Formatting.Indented;
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        app.UseWebApi(config);
    }
}