using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MagicNight.Services;

public class DraftTimerService : BackgroundService
{
    private IServiceProvider ServiceProvider { get; }
    
    public DraftTimerService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = ServiceProvider.CreateScope();
        var draftService = scope.ServiceProvider.GetRequiredService<DraftService>();
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}