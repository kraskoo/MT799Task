namespace MT799Service;

using Microsoft.EntityFrameworkCore;
using MT799Service.Repositories;
using MT799Service.Sections;
using MT799Service.Services;

public static class EntryPoint
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .AddJsonFile("appsettings.json")
            .Build();
        using var host = Host.CreateDefaultBuilder(args)
                             .UseWindowsService(options => options.ServiceName = "MT799 Service")
                             .ConfigureServices(configuration)
                             .Build();
        await MigrateDatabase(host);
        await host.RunAsync();
    }

    public static IHostBuilder ConfigureServices(this IHostBuilder builder, IConfiguration configuration) =>
        builder.ConfigureServices(services =>
            services.Configure<AppVariables>(options => configuration.GetSection(nameof(AppVariables)).Bind(options))
                    .AddDbContext<MT799Context>(
                        options => options.UseSqlServer(
                            configuration.GetConnectionString("MT799")),
                            contextLifetime: ServiceLifetime.Transient,
                            optionsLifetime: ServiceLifetime.Transient)
                    .AddTransient<IMessageRepository, MessageRepository>()
                    .AddTransient<IMT799WorkerService, MT799WorkerService>()
                    .AddHostedService<MT799Worker>());

    public static async Task MigrateDatabase(IHost host)
    {
        using var scope = host.Services.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<MT799Context>();
        await context.Database.MigrateAsync();
    }
}