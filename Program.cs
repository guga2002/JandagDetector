using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ManageLIbrary.Dbcontexti;
using ManageLIbrary.Services;
using ManageLIbrary.Context;
using Timer = System.Threading.Timer;

namespace Myapplikacia
{
    public static class Program
    {
        private static readonly string _connectionString = @"Server=DESKTOP-J7JC3FM\SQLEXPRESS;Database=Global;Trusted_Connection=True;TrustServerCertificate=True;";

        public static void Main(string[] args)
        {

            Timer timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<GlobalDbContext>((serviceProvider, options) =>
                    {
                        options.UseSqlServer(_connectionString);
                    });
                });
        public static void TimerCallback(object state)
        {
            GloabalContext cont = new GloabalContext();
            ManageGlobalServices ser = new ManageGlobalServices(cont);
            ser.start();
        }
    }

}
