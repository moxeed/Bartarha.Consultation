using Bartarha.Consultation.Core.Call;
using Bartarha.Consultation.Core.SponsorCall;
using Bartarha.Consultation.Infrastructure.Database;
using Bartarha.Consultation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bartarha.Consultation.Controllers.SponsorCall;

[Microsoft.AspNetCore.Components.Route("/sponsor-call/sponsor")]
public class SponsorController : ApiController
{
    private readonly ApplicationDbContext _context;
    private readonly CallService _callService;

    public SponsorController(ApplicationDbContext context, CallService callService)
    {
        _context = context;
        _callService = callService;
    }
    
    [HttpPost("candidate/{id:int}/start")]
    public async Task<IActionResult> Start(int id, [FromHeader] int userId)
    {
        var candidate = await _context.Set<Candidate>().FindAsync(id);

        if (candidate is null)
            return NotFound("این تماس پیدا نشد");
        
        var sponsor = await _context.Set<Sponsor>().FirstOrDefaultAsync(p => p.UserCode == userId);
        
        if (sponsor is null)
            return NotFound("اسپانسر تعریف نشده است");
        
        candidate.Trigger(_callService, sponsor);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpPost("candidate/{id:int}/report")]
    public async Task<IActionResult> Report(int id, [FromHeader] int userId, [FromBody] CallReportModel model)
    {
        var candidate = await _context.Set<Candidate>().FindAsync(id);

        if (candidate is null)
            return NotFound("این تماس پیدا نشد");
        
        var sponsor = await _context.Set<Sponsor>().FirstOrDefaultAsync(p => p.UserCode == userId);
        
        if (sponsor is null)
            return NotFound("اسپانسر تعریف نشده است");

        var report = new Report(sponsor, candidate, model.CallType, model.Result, userId, model.Description);
        _context.Attach(report);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
}