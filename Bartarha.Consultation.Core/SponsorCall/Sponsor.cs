using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.SponsorCall;

public class Sponsor : Entity
{
    public int UserCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
}