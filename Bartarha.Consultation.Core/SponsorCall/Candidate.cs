using Bartarha.Consultation.Core.Call;
using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.SponsorCall;

public class Candidate : Entity
{
    public string StudentName { get; set; }
    public string StudentPhoneNumber { get; set; }
    public Project Project { get; set; }
    public string ExternalKey => $"{nameof(Candidate)}-{Id}";

    public Candidate(Project project, string studentName, string studentPhoneNumber) : this()
    {
        Project = project;
        StudentName = studentName;
        StudentPhoneNumber = studentPhoneNumber;
    }

    private Candidate() { }

    public void Trigger(CallService callService, Sponsor sponsor)
    {
        if (!Project.IsActive)
        {
        }

        callService.QueueCall(sponsor.PhoneNumber
            , StudentPhoneNumber
            , Project.MaxDurationInSeconds
            , ExternalKey);
    }
}