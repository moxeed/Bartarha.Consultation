using Bartarha.Consultation.Core.Call;
using Bartarha.Consultation.Infrastructure.Database;
using Bartarha.Consultation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bartarha.Consultation.Controllers.Call;

public class CallBackController : ApiController
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CallBackController> _logger;

    public CallBackController(ApplicationDbContext context, ILogger<CallBackController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("/call-done")]
    public async Task<IActionResult> CallDone(CallResultModel model)
    {
        var attempt = _context.Set<CallAttempt>().FirstOrDefault(a => a.TracingCode == model.SessionId);

        if (attempt is null)
        {
            _logger.LogCritical("Attempt Not Found For VoipCall Back", model);
            return Ok();
        }

        var callResult = new CallResult(attempt, model.Status, model.DurationInSeconds);

        _context.Attach(callResult);
        await _context.SaveChangesAsync();
        return Ok();
    }
}