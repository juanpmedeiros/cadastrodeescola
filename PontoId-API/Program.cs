using PontoId_API;
using Microsoft.AspNetCore.Hosting;

namespace PontoId_API;
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
           .Build()
           .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}