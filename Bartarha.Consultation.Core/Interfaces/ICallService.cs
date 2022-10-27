
using Bartarha.Consultation.Core.Call;

namespace Bartarha.Consultation.Core.Interfaces;

public interface ICallService
{
    Task<string?> StartCall(CallRequest callRequest);
}