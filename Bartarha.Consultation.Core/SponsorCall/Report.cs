using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.SponsorCall;

public class Report : Entity
{
    public CallType CallType { get; set; }
    public Result Result { get; set; }
    public string Description { get; set; }
    
    public int CreateUserId { get; set; }
    public DateTime CreateDateTime { get; set; }
    
    public Candidate Candidate { get; set; }
    public Sponsor Sponsor { get; set; }

    public Report(Sponsor sponsor, Candidate candidate, CallType callType, Result result, int userId, string description) : this()
    {
        Sponsor = sponsor;
        Candidate = candidate;
        CallType = callType;
        Result = result;
        Description = description;
        
        CreateUserId = userId;
        CreateDateTime = DateTime.Now;
    }

    private Report() { }
}