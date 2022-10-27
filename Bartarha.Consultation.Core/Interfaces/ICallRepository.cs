using Bartarha.Consultation.Core.Call;

namespace Bartarha.Consultation.Core.Interfaces;

public interface ICallRepository
{
    Task Save(CallRequest request);
}