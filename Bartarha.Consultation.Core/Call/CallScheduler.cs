using Bartarha.Consultation.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bartarha.Consultation.Core.Call;

public class CallScheduler : BackgroundService
{
    private readonly ILogger<CallScheduler> _logger;
    private readonly IServiceProvider _serviceProvider;

    public CallScheduler(ILogger<CallScheduler> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();

            var repository = scope.ServiceProvider.GetRequiredService<ICallRepository>();
            var callService = scope.ServiceProvider.GetRequiredService<CallService>();
            var callProviderService = scope.ServiceProvider.GetRequiredService<ICallService>();

            var requestCount = repository.GetPendingRequestsCount();
            if (requestCount > 0)
            {
                CallService.RequestSemaphore.Release(requestCount);
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await CallService.RequestSemaphore.WaitAsync(stoppingToken);
                var requests = repository.GetTopPendingRequests(10);

                foreach (var request in requests)
                {
                    CallService.RequestSemaphore.Release();
                    await callService.StartCall(request, callProviderService, stoppingToken);
                    await repository.CommitAsync();
                }
            }
        }
        catch (Exception e)
        {
            
        }
    }
}