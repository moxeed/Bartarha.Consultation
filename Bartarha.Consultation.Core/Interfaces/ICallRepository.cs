using Bartarha.Consultation.Core.Call;

namespace Bartarha.Consultation.Core.Interfaces;

public interface ICallRepository
{
    void Save(CallRequest request);
    void Save(CallAttempt attempt);
    IEnumerable<CallRequest> GetTopPendingRequests(int count);
    int GetPendingRequestsCount();
    Task CommitAsync();
}