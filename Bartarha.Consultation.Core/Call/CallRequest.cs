using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.Call;

public class CallRequest : Entity
{
    public string Isr { get; set; } = string.Empty;
    public string CallerPhoneNumber { get; set; } = string.Empty;
    public string CalleePhoneNumber { get; set; } = string.Empty;
    public int MaxDurationInSeconds { get; set; }
}