using Bartarha.Consultation.Core.SponsorCall;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bartarha.Consultation.Infrastructure.Configuration;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.Navigation(p => p.Project).AutoInclude();
    }
}