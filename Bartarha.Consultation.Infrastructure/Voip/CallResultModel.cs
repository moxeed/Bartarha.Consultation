namespace Bartarha.Consultation.Infrastructure.Voip;

public class CallResultModel
{
    public string SessionId { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}