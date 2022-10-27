using System.Text.Json;
using Bartarha.Consultation.Core.Call;
using Bartarha.Consultation.Core.Interfaces;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bartarha.Consultation.Infrastructure.Voip;

public class VoipService : ICallService
{
    private readonly ILogger<VoipService> _logger;
    private readonly VoipOptions _options;

    public VoipService(IOptions<VoipOptions> options, ILogger<VoipService> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    public async Task<string?> StartCall(CallRequest callRequest)
    {
        var body = new CallRequestModel
        {
            Token = _options.Token,
            CallBack = _options.CallBackUrl,
            Destination = callRequest.CalleePhoneNumber,
            Source = callRequest.CallerPhoneNumber,
            Duration = callRequest.MaxDurationInSeconds.ToString()
        };
        
        try
        {
            var response = await _options.VoipUrl.PostJsonAsync(body).ReceiveJson<StartCallResult>();
            return response.TracingCode;
        }
        catch(Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }
}