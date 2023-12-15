using Database.Models;
using Database.Repositories.ComputerInfoRepository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class MyBackgroundService : BackgroundService
{
    private readonly IServiceScopeFactory _iservicescopefactory;

    public MyBackgroundService(IServiceScopeFactory iservicescopefactory)
    {
        _iservicescopefactory = iservicescopefactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _iservicescopefactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IComputerInfoRepository>();
        while (!stoppingToken.IsCancellationRequested)
        {
            var computerInfo = await service.GetComputerInfoAsync(1);
            Console.WriteLine($"Полуличил компьютер с именем: {computerInfo.ComputerName}");
            await Task.Delay(5000, stoppingToken);
        }
    }

}