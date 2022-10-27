using Bartarha.Consultation.Core.Interfaces;

namespace Bartarha.Consultation.Core.Call;

public class CallService
{
    private readonly ICallRepository _callRepository;

    public CallService(ICallRepository callRepository)
    {
        _callRepository = callRepository;
    }

    public void QueueCall(string callerPhoneNumber, string calleePhoneNumber, int maxDurationInSeconds, string isr)
    {
        var callRequest = new CallRequest
        {
            CalleePhoneNumber = calleePhoneNumber,
            CallerPhoneNumber = callerPhoneNumber,
            MaxDurationInSeconds = maxDurationInSeconds,
            Isr = isr
        };

        _callRepository.Save(callRequest);
    }
}