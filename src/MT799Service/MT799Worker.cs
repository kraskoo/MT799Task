namespace MT799Service;

using Microsoft.Extensions.Options;
using MT799Service.Sections;
using MT799Service.Services;
using System.Collections.Generic;

public class MT799Worker : BackgroundService
{
    private readonly AppVariables variables;
    private readonly IMT799WorkerService service;
    private readonly HashSet<string> files;

    public MT799Worker(IOptions<AppVariables> variablesOptions, IMT799WorkerService service)
    {
        this.variables = variablesOptions.Value;
        this.service = service;
        this.files = new HashSet<string>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Directory.CreateDirectory(this.variables.MT799Path);
            var files = Directory.GetFiles(this.variables.MT799Path).Except(this.files);
            await this.ApplyFiles(files);
            await Task.Delay(TimeSpan.FromSeconds(this.variables.SecondsDelay), stoppingToken);
        }
    }

    private async Task ApplyFiles(IEnumerable<string> files)
    {
        var fileTexts = files.Select(f => File.ReadAllText(f)).ToArray();
        foreach (var file in files)
        {
            this.files.Add(file);
        }

        await this.service.CreateRecords(fileTexts);
    }
}