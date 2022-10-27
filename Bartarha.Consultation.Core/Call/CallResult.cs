using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.Call;

public class CallResult : Entity
{
    public int DurationInSeconds { get; set; } 
    public string Status { get; set; }
    public CallAttempt CallAttempt { get; set; }

    public CallResult(CallAttempt callAttempt, string status, int durationInSeconds) : this()
    {
        CallAttempt = callAttempt;
        Status = status;
        DurationInSeconds = durationInSeconds;
    }
    
    private CallResult() { }
}