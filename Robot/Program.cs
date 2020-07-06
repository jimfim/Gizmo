using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Robot
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IMotorController, MotorController>();
                    services.AddSingleton<IPacketParser, PacketParser>();
                    services.AddHostedService<CommandServer>();
                });
    }
}