using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.Call;

public class CallAttempt : Entity
{
    public DateTime CreateDateTime { get; set; }
    public string TracingCode { get; set; }
    
    public CallRequest CallRequest { get; set; }

    public CallAttempt(CallRequest callRequest, string tracingCode) : this()
    {
        CallRequest = callRequest;
        TracingCode = tracingCode;

        CreateDateTime = DateTime.Now;
    }

    private CallAttempt() { }
}