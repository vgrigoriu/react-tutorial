using System;
using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
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

        app.UseWebApi(config);
    }
}