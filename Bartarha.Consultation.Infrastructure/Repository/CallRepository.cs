using Bartarha.Consultation.Core.Call;
using Bartarha.Consultation.Core.Interfaces;
using Bartarha.Consultation.Infrastructure.Database;

namespace Bartarha.Consultation.Infrastructure.Repository;

public class CallRepository : ICallRepository
{
    private readonly ApplicationDbContext _context;

    public CallRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Save(CallRequest request)
    {
        _context.Attach(request);
    }

    public void Save(CallAttempt attempt)
    {
        _context.Attach(attempt);
    }

    public IEnumerable<CallRequest> GetTopPendingRequests(int count)
    {
        return _context.Set<CallRequest>()
            .Where(r => !r.Attempts.Any())
            .Take(count)
            .ToList();
    }

    public int GetPendingRequestsCount()
    {
        return _context.Set<CallRequest>()
            .Count(r => !r.Attempts.Any());
    }

    public Task CommitAsync()
    {
        return _context.SaveChangesAsync();
    }
}