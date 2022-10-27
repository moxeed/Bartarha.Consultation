using Bartarha.Consultation.Core.Common;

namespace Bartarha.Consultation.Core.SponsorCall;

public class Project : Entity
{
    public string Name { get; set; }
    public int MaxDurationInSeconds { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreateDateTime { get; set; }

    public List<Candidate> Candidates { get; set; }
    public bool IsActive => StartDateTime < DateTime.Now && EndDateTime > DateTime.Now;

    public Project(string name, DateTime startDateTime, DateTime endDateTime, DateTime createDateTime) : this()
    {
        Name = name;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        CreateDateTime = createDateTime;
    }

    private Project()
    {
        Candidates = new List<Candidate>();
    }

    public void AddCandidates(IEnumerable<Candidate> candidates)
    {
        Candidates.AddRange(candidates);
    }
}