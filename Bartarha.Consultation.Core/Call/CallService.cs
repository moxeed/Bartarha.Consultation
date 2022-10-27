using Bartarha.Consultation.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bartarha.Consultation.Core.Call;

public class CallService
{
    private static readonly SemaphoreSlim Semaphore = new(30);
    public static readonly SemaphoreSlim RequestSemaphore = new(0);
    private readonly ICallRepository _callRepository;
    private readonly ILogger<CallService> _logger;

    public CallService(ICallRepository callRepository, ILogger<CallService> logger)
    {
        _callRepository = callRepository;
        _logger = logger;
    }

    public async Task QueueCall(string callerPhoneNumber, string calleePhoneNumber, int maxDurationInSeconds, string isr)
    {
        var callRequest = new CallRequest
        {
            CalleePhoneNumber = calleePhoneNumber,
            CallerPhoneNumber = callerPhoneNumber,
            MaxDurationInSeconds = maxDurationInSeconds,
            Isr = isr
        };

        _callRepository.Save(callRequest);
        await _callRepository.CommitAsync();
        
        RequestSemaphore.Release();
    }

    public async Task StartCall(CallRequest request, ICallService callService, CancellationToken token)
    {
        await Semaphore.WaitAsync(token);
        
        var result = await callService.StartCall(request);
        if (result is null)
        {
            _logger.LogCritical("Failed To StartCall RequestID:" + request.Id);
        }

        var attempt = new CallAttempt(request, result);
        _callRepository.Save(attempt);
        
        await RequestSemaphore.WaitAsync(token);
    }
}