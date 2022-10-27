using Bartarha.Consultation.Core.SponsorCall;

namespace Bartarha.Consultation.Models;

public class CallReportModel
{
    public CallType CallType { get; set; }
    public Result Result { get; set; }
    public string Description { get; set; } = string.Empty;
}