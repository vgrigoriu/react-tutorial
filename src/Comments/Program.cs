using System;
using Microsoft.Owin.Hosting;
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
        app.UseFileServer(true);
    }
}