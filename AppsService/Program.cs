using AppsService;
using Microsoft.Extensions.Hosting;

Directory.CreateDirectory("C:\\Logs");

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    }).Build();
host.Run();